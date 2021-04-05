using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace ET
{
    public struct KcpWaitPacket
    {
        public long ActorId;
        public MemoryStream MemoryStream;
    }

    public class KChannel: AChannel
    {
        public KService Service;

        // 保存所有的channel
        public static readonly Dictionary<uint, KChannel> kChannels = new Dictionary<uint, KChannel>();

        public static readonly ConcurrentDictionary<long, ulong> idLocalRemoteConn = new ConcurrentDictionary<long, ulong>();

        private Socket socket;

        private IntPtr kcp;

        private readonly Queue<KcpWaitPacket> sendBuffer = new Queue<KcpWaitPacket>();

        private uint lastRecvTime;

        public readonly uint CreateTime;

        public uint LocalConn { get; set; }
        public uint RemoteConn { get; set; }

        private readonly byte[] sendCache = new byte[1024 * 1024];

        public bool IsConnected { get; private set; }

        public string RealAddress { get; set; }

        private void InitKcp()
        {
            switch (Service.ServiceType)
            {
                case ServiceType.Inner:
                    Kcp.KcpNodelay(kcp, 1, 10, 2, 1);
                    Kcp.KcpWndsize(kcp, 1024 * 100, 1024 * 100);
                    Kcp.KcpSetmtu(kcp, 1400); // 默认1400
                    Kcp.KcpSetminrto(kcp, 10);
                    break;
                case ServiceType.Outer:
                    Kcp.KcpNodelay(kcp, 1, 10, 2, 1);
                    Kcp.KcpWndsize(kcp, 128, 128);
                    Kcp.KcpSetmtu(kcp, 470);
                    Kcp.KcpSetminrto(kcp, 10);
                    break;
            }
        }

        // connect
        public KChannel(long id, uint localConn, Socket socket, IPEndPoint remoteEndPoint, KService kService)
        {
            LocalConn = localConn;
            if (kChannels.ContainsKey(LocalConn))
            {
                throw new Exception($"channel create error: {LocalConn} {remoteEndPoint} {ChannelType}");
            }

            Id = id;
            ChannelType = ChannelType.Connect;

            Log.Info($"channel create: {Id} {LocalConn} {remoteEndPoint} {ChannelType}");

            Service = kService;
            RemoteAddress = remoteEndPoint;
            this.socket = socket;
            kcp = Kcp.KcpCreate(RemoteConn, (IntPtr) LocalConn);

            kChannels.Add(LocalConn, this);

            lastRecvTime = kService.TimeNow;
            CreateTime = kService.TimeNow;

            Connect();
        }

        // accept
        public KChannel(long id, uint localConn, uint remoteConn, Socket socket, IPEndPoint remoteEndPoint, KService kService)
        {
            if (kChannels.ContainsKey(LocalConn))
            {
                throw new Exception($"channel create error: {localConn} {remoteEndPoint} {ChannelType}");
            }

            Id = id;
            ChannelType = ChannelType.Accept;

            Log.Info($"channel create: {Id} {localConn} {remoteConn} {remoteEndPoint} {ChannelType}");

            Service = kService;
            LocalConn = localConn;
            RemoteConn = remoteConn;
            RemoteAddress = remoteEndPoint;
            this.socket = socket;
            kcp = Kcp.KcpCreate(RemoteConn, (IntPtr) localConn);

            kChannels.Add(LocalConn, this);

            lastRecvTime = kService.TimeNow;
            CreateTime = kService.TimeNow;

            InitKcp();
        }

        #region 网络线程

        public override void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            uint localConn = LocalConn;
            uint remoteConn = RemoteConn;
            Log.Info($"channel dispose: {Id} {localConn} {remoteConn}");

            kChannels.Remove(localConn);
            idLocalRemoteConn.TryRemove(Id, out ulong _);

            long id = Id;
            Id = 0;
            Service.Remove(id);

            try
            {
                //this.Service.Disconnect(localConn, remoteConn, this.Error, this.RemoteAddress, 3);
            }

            catch (Exception e)
            {
                Log.Error(e);
            }

            if (kcp != IntPtr.Zero)
            {
                Kcp.KcpRelease(kcp);
                kcp = IntPtr.Zero;
            }

            socket = null;
        }

        public void HandleConnnect()
        {
            // 如果连接上了就不用处理了
            if (IsConnected)
            {
                return;
            }

            kcp = Kcp.KcpCreate(RemoteConn, new IntPtr(LocalConn));
            InitKcp();

            ulong localRmoteConn = ((ulong) RemoteConn << 32) | LocalConn;
            idLocalRemoteConn.TryAdd(Id, localRmoteConn);

            Log.Info($"channel connected: {Id} {LocalConn} {RemoteConn} {RemoteAddress}");
            IsConnected = true;
            lastRecvTime = Service.TimeNow;

            while (true)
            {
                if (sendBuffer.Count <= 0)
                {
                    break;
                }

                KcpWaitPacket buffer = sendBuffer.Dequeue();
                KcpSend(buffer);
            }
        }

        /// <summary>
        /// 发送请求连接消息
        /// </summary>
        private void Connect()
        {
            try
            {
                uint timeNow = Service.TimeNow;

                lastRecvTime = timeNow;

                byte[] buffer = sendCache;
                buffer.WriteTo(0, KcpProtocalType.SYN);
                buffer.WriteTo(1, LocalConn);
                buffer.WriteTo(5, RemoteConn);
                socket.SendTo(buffer, 0, 9, SocketFlags.None, RemoteAddress);
                Log.Info($"kchannel connect {Id} {LocalConn} {RemoteConn} {RealAddress} {socket.LocalEndPoint}");
                // 200毫秒后再次update发送connect请求
                Service.AddToUpdateNextTime(timeNow + 300, Id);
            }
            catch (Exception e)
            {
                Log.Error(e);
                OnError(ErrorCode.ERR_SocketCantSend);
            }
        }

        public void Update()
        {
            if (IsDisposed)
            {
                return;
            }

            uint timeNow = Service.TimeNow;

            // 如果还没连接上，发送连接请求
            if (!IsConnected)
            {
                // 20秒没连接上则报错
                if (timeNow - CreateTime > 10 * 1000)
                {
                    Log.Error($"kChannel connect timeout: {Id} {RemoteConn} {timeNow} {CreateTime} {ChannelType} {RemoteAddress}");
                    OnError(ErrorCode.ERR_KcpConnectTimeout);
                    return;
                }

                switch (ChannelType)
                {
                    case ChannelType.Connect:
                        Connect();
                        break;
                }

                return;
            }

            try
            {
                Kcp.KcpUpdate(kcp, timeNow);
            }
            catch (Exception e)
            {
                Log.Error(e);
                OnError(ErrorCode.ERR_SocketError);
                return;
            }

            if (kcp != IntPtr.Zero)
            {
                uint nextUpdateTime = Kcp.KcpCheck(kcp, timeNow);
                Service.AddToUpdateNextTime(nextUpdateTime, Id);
            }
        }

        public void HandleRecv(byte[] date, int offset, int length)
        {
            if (IsDisposed)
            {
                return;
            }

            IsConnected = true;

            Kcp.KcpInput(kcp, date, offset, length);
            Service.AddToUpdateNextTime(0, Id);

            while (true)
            {
                if (IsDisposed)
                {
                    break;
                }

                int n = Kcp.KcpPeeksize(kcp);
                if (n < 0)
                {
                    break;
                }

                if (n == 0)
                {
                    OnError((int) SocketError.NetworkReset);
                    break;
                }

                MemoryStream ms = MessageSerializeHelper.GetStream(n);

                ms.SetLength(n);
                ms.Seek(0, SeekOrigin.Begin);
                byte[] buffer = ms.GetBuffer();
                int count = Kcp.KcpRecv(kcp, buffer, n);
                if (n != count)
                {
                    break;
                }

                switch (Service.ServiceType)
                {
                    case ServiceType.Inner:
                        ms.Seek(Packet.ActorIdLength + Packet.OpcodeLength, SeekOrigin.Begin);
                        break;
                    case ServiceType.Outer:
                        ms.Seek(Packet.OpcodeLength, SeekOrigin.Begin);
                        break;
                }

                lastRecvTime = Service.TimeNow;
                OnRead(ms);
            }
        }

        public void Output(IntPtr bytes, int count)
        {
            if (IsDisposed)
            {
                return;
            }

            try
            {
                // 没连接上 kcp不往外发消息, 其实本来没连接上不会调用update，这里只是做一层保护
                if (!IsConnected)
                {
                    return;
                }

                if (count == 0)
                {
                    Log.Error($"output 0");
                    return;
                }

                byte[] buffer = sendCache;
                buffer.WriteTo(0, KcpProtocalType.MSG);
                // 每个消息头部写下该channel的id;
                buffer.WriteTo(1, LocalConn);
                Marshal.Copy(bytes, buffer, 5, count);
                socket.SendTo(buffer, 0, count + 5, SocketFlags.None, RemoteAddress);
            }
            catch (Exception e)
            {
                Log.Error(e);
                OnError(ErrorCode.ERR_SocketCantSend);
            }
        }

        private void KcpSend(KcpWaitPacket kcpWaitPacket)
        {
            if (IsDisposed)
            {
                return;
            }

            MemoryStream memoryStream = kcpWaitPacket.MemoryStream;
            if (Service.ServiceType == ServiceType.Inner)
            {
                memoryStream.GetBuffer().WriteTo(0, kcpWaitPacket.ActorId);
            }

            int count = (int) (memoryStream.Length - memoryStream.Position);
            Kcp.KcpSend(kcp, memoryStream.GetBuffer(), (int) memoryStream.Position, count);
            Service.AddToUpdateNextTime(0, Id);
        }

        public void Send(long actorId, MemoryStream stream)
        {
            if (kcp != IntPtr.Zero)
            {
                // 检查等待发送的消息，如果超出最大等待大小，应该断开连接
                int n = Kcp.KcpWaitsnd(kcp);

                int maxWaitSize = 0;
                switch (Service.ServiceType)
                {
                    case ServiceType.Inner:
                        maxWaitSize = Kcp.InnerMaxWaitSize;
                        break;
                    case ServiceType.Outer:
                        maxWaitSize = Kcp.OuterMaxWaitSize;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (n > maxWaitSize)
                {
                    Log.Error($"kcp wait snd too large: {n}: {Id} {RemoteConn}");
                    OnError(ErrorCode.ERR_KcpWaitSendSizeTooLarge);
                    return;
                }
            }

            KcpWaitPacket kcpWaitPacket = new KcpWaitPacket() { ActorId = actorId, MemoryStream = stream };
            if (!IsConnected)
            {
                sendBuffer.Enqueue(kcpWaitPacket);
                return;
            }

            KcpSend(kcpWaitPacket);
        }

        private void OnRead(MemoryStream memoryStream)
        {
            Service.OnRead(Id, memoryStream);
        }

        public void OnError(int error)
        {
            long channelId = Id;
            Service.Remove(channelId);
            Service.OnError(channelId, error);
        }

        #endregion
    }
}