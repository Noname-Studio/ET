using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace ET
{
    public sealed class TService: AService
    {
        private readonly Dictionary<long, TChannel> idChannels = new Dictionary<long, TChannel>();

        private readonly SocketAsyncEventArgs innArgs = new SocketAsyncEventArgs();

        private Socket acceptor;

        public HashSet<long> NeedStartSend = new HashSet<long>();

        public TService(ThreadSynchronizationContext threadSynchronizationContext, ServiceType serviceType)
        {
            ServiceType = serviceType;
            ThreadSynchronizationContext = threadSynchronizationContext;
        }

        public TService(ThreadSynchronizationContext threadSynchronizationContext, IPEndPoint ipEndPoint, ServiceType serviceType)
        {
            ServiceType = serviceType;
            ThreadSynchronizationContext = threadSynchronizationContext;
            Log.Info("注册服务器成功:" + ipEndPoint);
            acceptor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            acceptor.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            innArgs.Completed += OnComplete;
            acceptor.Bind(ipEndPoint);
            acceptor.Listen(1000);

            ThreadSynchronizationContext.PostNext(AcceptAsync);
        }

        private void OnComplete(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Accept:
                    SocketError socketError = e.SocketError;
                    Socket acceptSocket = e.AcceptSocket;
                    ThreadSynchronizationContext.Post(() => { OnAcceptComplete(socketError, acceptSocket); });
                    break;
                default:
                    throw new Exception($"socket error: {e.LastOperation}");
            }
        }

        #region 网络线程

        private void OnAcceptComplete(SocketError socketError, Socket acceptSocket)
        {
            if (acceptor == null)
            {
                return;
            }

            // 开始新的accept
            AcceptAsync();

            if (socketError != SocketError.Success)
            {
                Log.Error($"accept error {socketError}");
                return;
            }

            try
            {
                long id = CreateAcceptChannelId(0);
                TChannel channel = new TChannel(id, acceptSocket, this);
                idChannels.Add(channel.Id, channel);
                long channelId = channel.Id;
                Log.Info("收到客户端的连接请求:" + id);
                OnAccept(channelId, channel.RemoteAddress);
            }
            catch (Exception exception)
            {
                Log.Error(exception);
            }
        }

        private void AcceptAsync()
        {
            innArgs.AcceptSocket = null;
            if (acceptor.AcceptAsync(innArgs))
            {
                return;
            }

            OnAcceptComplete(innArgs.SocketError, innArgs.AcceptSocket);
        }

        private TChannel Create(IPEndPoint ipEndPoint, long id)
        {
            TChannel channel = new TChannel(id, ipEndPoint, this);
            idChannels.Add(channel.Id, channel);
            return channel;
        }

        protected override void Get(long id, IPEndPoint address)
        {
            if (idChannels.TryGetValue(id, out TChannel _))
            {
                return;
            }

            Create(address, id);
        }

        private TChannel Get(long id)
        {
            TChannel channel = null;
            idChannels.TryGetValue(id, out channel);
            return channel;
        }

        public override void Dispose()
        {
            acceptor?.Close();
            acceptor = null;
            innArgs.Dispose();
            ThreadSynchronizationContext = null;

            foreach (long id in idChannels.Keys.ToArray())
            {
                TChannel channel = idChannels[id];
                channel.Dispose();
            }

            idChannels.Clear();
        }

        public override void Remove(long id)
        {
            if (idChannels.TryGetValue(id, out TChannel channel))
            {
                channel.Dispose();
            }

            idChannels.Remove(id);
        }

        protected override void Send(long channelId, long actorId, MemoryStream stream)
        {
            try
            {
                TChannel aChannel = Get(channelId);
                if (aChannel == null)
                {
                    OnError(channelId, ErrorCode.ERR_SendMessageNotFoundTChannel);
                    return;
                }

                aChannel.Send(actorId, stream);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public override void Update()
        {
            foreach (long channelId in NeedStartSend)
            {
                TChannel tChannel = Get(channelId);
                tChannel?.Update();
            }

            NeedStartSend.Clear();
        }

        public override bool IsDispose()
        {
            return ThreadSynchronizationContext == null;
        }

        #endregion
    }
}