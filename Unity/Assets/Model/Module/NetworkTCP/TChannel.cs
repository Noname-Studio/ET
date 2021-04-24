﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace ET
{
    /// <summary>
    /// 封装Socket,将回调push到主线程处理
    /// </summary>
    public sealed class TChannel: AChannel
    {
        private readonly TService Service;
        private Socket socket;
        private SocketAsyncEventArgs innArgs = new SocketAsyncEventArgs();
        private SocketAsyncEventArgs outArgs = new SocketAsyncEventArgs();

        private readonly CircularBuffer recvBuffer = new CircularBuffer();
        private readonly CircularBuffer sendBuffer = new CircularBuffer();

        private bool isSending;

        private bool isConnected;

        private readonly PacketParser parser;

        private readonly byte[] sendCache = new byte[Packet.OpcodeLength + Packet.ActorIdLength];

        private void OnComplete(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Connect:
                    Service.ThreadSynchronizationContext.Post(() => OnConnectComplete(e));
                    break;
                case SocketAsyncOperation.Receive:
                    Service.ThreadSynchronizationContext.Post(() => OnRecvComplete(e));
                    break;
                case SocketAsyncOperation.Send:
                    Service.ThreadSynchronizationContext.Post(() => OnSendComplete(e));
                    break;
                case SocketAsyncOperation.Disconnect:
                    Service.ThreadSynchronizationContext.Post(() => OnDisconnectComplete(e));
                    break;
                default:
                    throw new Exception($"socket error: {e.LastOperation}");
            }
        }

        #region 网络线程

        public TChannel(long id, IPEndPoint ipEndPoint, TService service)
        {
            ChannelType = ChannelType.Connect;
            Id = id;
            Service = service;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.NoDelay = true;
            parser = new PacketParser(recvBuffer, Service);
            innArgs.Completed += OnComplete;
            outArgs.Completed += OnComplete;

            RemoteAddress = ipEndPoint;
            isConnected = false;
            isSending = false;

            Service.ThreadSynchronizationContext.PostNext(ConnectAsync);
        }

        public TChannel(long id, Socket socket, TService service)
        {
            ChannelType = ChannelType.Accept;
            Id = id;
            Service = service;
            this.socket = socket;
            this.socket.NoDelay = true;
            parser = new PacketParser(recvBuffer, Service);
            innArgs.Completed += OnComplete;
            outArgs.Completed += OnComplete;

            RemoteAddress = (IPEndPoint) socket.RemoteEndPoint;
            isConnected = true;
            isSending = false;

            // 下一帧再开始读写
            Service.ThreadSynchronizationContext.PostNext(() =>
            {
                StartRecv();
                StartSend();
            });
        }

        public override void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            Log.Info($"channel dispose: {Id} {RemoteAddress}");

            long id = Id;
            Id = 0;
            Service.Remove(id);
            socket.Close();
            innArgs.Dispose();
            outArgs.Dispose();
            innArgs = null;
            outArgs = null;
            socket = null;
        }

        public void Send(long actorId, MemoryStream stream)
        {
            if (IsDisposed)
            {
                throw new Exception("TChannel已经被Dispose, 不能发送消息");
            }

            switch (Service.ServiceType)
            {
                case ServiceType.Inner:
                {
                    int messageSize = (int) (stream.Length - stream.Position);
                    if (messageSize > ushort.MaxValue * 16)
                    {
                        throw new Exception($"send packet too large: {stream.Length} {stream.Position}");
                    }

                    sendCache.WriteTo(0, messageSize);
                    sendBuffer.Write(sendCache, 0, PacketParser.InnerPacketSizeLength);

                    // actorId
                    stream.GetBuffer().WriteTo(0, actorId);
                    sendBuffer.Write(stream.GetBuffer(), (int) stream.Position, (int) (stream.Length - stream.Position));
                    break;
                }
                case ServiceType.Outer:
                {
                    ushort messageSize = (ushort) (stream.Length - stream.Position);

                    sendCache.WriteTo(0, messageSize);
                    sendBuffer.Write(sendCache, 0, PacketParser.OuterPacketSizeLength);

                    sendBuffer.Write(stream.GetBuffer(), (int) stream.Position, (int) (stream.Length - stream.Position));
                    break;
                }
            }

            if (!isSending)
            {
                //this.StartSend();
                Service.NeedStartSend.Add(Id);
            }
        }

        private void ConnectAsync()
        {
            outArgs.RemoteEndPoint = RemoteAddress;
            if (socket.ConnectAsync(outArgs))
            {
                return;
            }

            OnConnectComplete(outArgs);
        }

        private void OnConnectComplete(object o)
        {
            if (socket == null)
            {
                return;
            }

            SocketAsyncEventArgs e = (SocketAsyncEventArgs) o;
            if (e.SocketError != SocketError.Success)
            {
                OnError((int) e.SocketError);
                return;
            }

            e.RemoteEndPoint = null;
            isConnected = true;
            StartRecv();
            StartSend();
        }

        private void OnDisconnectComplete(object o)
        {
            SocketAsyncEventArgs e = (SocketAsyncEventArgs) o;
            OnError((int) e.SocketError);
        }

        private void StartRecv()
        {
            while (true)
            {
                try
                {
                    if (socket == null)
                    {
                        return;
                    }

                    int size = recvBuffer.ChunkSize - recvBuffer.LastIndex;
                    innArgs.SetBuffer(recvBuffer.Last, recvBuffer.LastIndex, size);
                }
                catch (Exception e)
                {
                    Log.Error($"tchannel error: {Id}\n{e}");
                    OnError(ErrorCode.ERR_TChannelRecvError);
                    return;
                }

                if (socket.ReceiveAsync(innArgs))
                {
                    return;
                }

                HandleRecv(innArgs);
            }
        }

        private void OnRecvComplete(object o)
        {
            HandleRecv(o);

            if (socket == null)
            {
                return;
            }

            StartRecv();
        }

        private void HandleRecv(object o)
        {
            if (socket == null)
            {
                return;
            }

            SocketAsyncEventArgs e = (SocketAsyncEventArgs) o;

            if (e.SocketError != SocketError.Success)
            {
                OnError((int) e.SocketError);
                return;
            }

            if (e.BytesTransferred == 0)
            {
                OnError(ErrorCode.ERR_PeerDisconnect);
                return;
            }

            recvBuffer.LastIndex += e.BytesTransferred;
            if (recvBuffer.LastIndex == recvBuffer.ChunkSize)
            {
                recvBuffer.AddLast();
                recvBuffer.LastIndex = 0;
            }

            // 收到消息回调
            while (true)
            {
                // 这里循环解析消息执行，有可能，执行消息的过程中断开了session
                if (socket == null)
                {
                    return;
                }

                try
                {
                    bool ret = parser.Parse();
                    if (!ret)
                    {
                        break;
                    }

                    OnRead(parser.MemoryStream);
                }
                catch (Exception ee)
                {
                    Log.Error($"ip: {RemoteAddress} {ee}");
                    OnError(ErrorCode.ERR_SocketError);
                    return;
                }
            }
        }

        public void Update()
        {
            StartSend();
        }

        private void StartSend()
        {
            if (!isConnected)
            {
                return;
            }

            while (true)
            {
                try
                {
                    if (socket == null)
                    {
                        return;
                    }

                    // 没有数据需要发送
                    if (sendBuffer.Length == 0)
                    {
                        isSending = false;
                        return;
                    }

                    isSending = true;

                    int sendSize = sendBuffer.ChunkSize - sendBuffer.FirstIndex;
                    if (sendSize > sendBuffer.Length)
                    {
                        sendSize = (int) sendBuffer.Length;
                    }

                    outArgs.SetBuffer(sendBuffer.First, sendBuffer.FirstIndex, sendSize);

                    if (socket.SendAsync(outArgs))
                    {
                        return;
                    }

                    HandleSend(outArgs);
                }
                catch (Exception e)
                {
                    throw new Exception($"socket set buffer error: {sendBuffer.First.Length}, {sendBuffer.FirstIndex}", e);
                }
            }
        }

        private void OnSendComplete(object o)
        {
            HandleSend(o);

            StartSend();
        }

        private void HandleSend(object o)
        {
            if (socket == null)
            {
                return;
            }

            SocketAsyncEventArgs e = (SocketAsyncEventArgs) o;

            if (e.SocketError != SocketError.Success)
            {
                OnError((int) e.SocketError);
                return;
            }

            if (e.BytesTransferred == 0)
            {
                OnError(ErrorCode.ERR_PeerDisconnect);
                return;
            }

            sendBuffer.FirstIndex += e.BytesTransferred;
            if (sendBuffer.FirstIndex == sendBuffer.ChunkSize)
            {
                sendBuffer.FirstIndex = 0;
                sendBuffer.RemoveFirst();
            }
        }

        private void OnRead(MemoryStream memoryStream)
        {
            try
            {
                long channelId = Id;
                Service.OnRead(channelId, memoryStream);
            }
            catch (Exception e)
            {
                Log.Error($"{RemoteAddress} {memoryStream.Length} {e}");
                // 出现任何消息解析异常都要断开Session，防止客户端伪造消息
                OnError(ErrorCode.ERR_PacketParserError);
            }
        }

        private void OnError(int error)
        {
            Log.Error($"TChannel error: {error} {RemoteAddress}");

            long channelId = Id;

            Service.Remove(channelId);

            Service.OnError(channelId, error);
        }

        #endregion
    }
}