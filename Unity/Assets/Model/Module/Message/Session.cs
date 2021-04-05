using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace ET
{
    [ObjectSystem]
    public class SessionAwakeSystem: AwakeSystem<Session, AService>
    {
        public override void Awake(Session self, AService aService)
        {
            self.Awake(aService);
        }
    }

    public sealed class Session: Entity
    {
        private readonly struct RpcInfo
        {
            public readonly IRequest Request;
            public readonly ETTaskCompletionSource<IResponse> Tcs;

            public RpcInfo(IRequest request)
            {
                Request = request;
                Tcs = new ETTaskCompletionSource<IResponse>();
            }
        }

        public AService AService;

        private static int RpcId { get; set; }

        private readonly Dictionary<int, RpcInfo> requestCallbacks = new Dictionary<int, RpcInfo>();

        public long LastRecvTime { get; set; }

        public long LastSendTime { get; set; }

        public int Error { get; set; }

        public void Awake(AService aService)
        {
            AService = aService;
            long timeNow = TimeHelper.ClientNow();
            LastRecvTime = timeNow;
            LastSendTime = timeNow;

            requestCallbacks.Clear();

            Log.Info($"session create: zone: {this.DomainZone()} id: {Id} {timeNow} ");
        }

        public override void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            int zone = this.DomainZone();
            long id = Id;

            base.Dispose();

            AService.RemoveChannel(Id);

            foreach (RpcInfo responseCallback in requestCallbacks.Values.ToArray())
            {
                responseCallback.Tcs.SetException(new RpcException(Error, $"session dispose: {id} {RemoteAddress}"));
            }

            Log.Info($"session dispose: {RemoteAddress} zone: {zone} id: {id} ErrorCode: {Error}, please see ErrorCode.cs! {TimeHelper.ClientNow()}");

            requestCallbacks.Clear();
        }

        public IPEndPoint RemoteAddress { get; set; }

        public void OnRead(ushort opcode, IResponse response)
        {
            OpcodeHelper.LogMsg(this.DomainZone(), opcode, response);

            if (!requestCallbacks.TryGetValue(response.RpcId, out var action))
            {
                return;
            }

            requestCallbacks.Remove(response.RpcId);
            if (ErrorCode.IsRpcNeedThrowException(response.Error))
            {
                action.Tcs.SetException(new Exception($"Rpc error, request: {action.Request} response: {response}"));
                return;
            }

            action.Tcs.SetResult(response);
        }

        public async ETTask<IResponse> Call(IRequest request, ETCancellationToken cancellationToken)
        {
            int rpcId = ++RpcId;
            RpcInfo rpcInfo = new RpcInfo(request);
            requestCallbacks[rpcId] = rpcInfo;
            request.RpcId = rpcId;

            Send(request);

            void CancelAction()
            {
                if (!requestCallbacks.TryGetValue(rpcId, out RpcInfo action))
                {
                    return;
                }

                requestCallbacks.Remove(rpcId);
                Type responseType = OpcodeTypeComponent.Instance.GetResponseType(action.Request.GetType());
                IResponse response = (IResponse) Activator.CreateInstance(responseType);
                response.Error = ErrorCode.ERR_Cancel;
                action.Tcs.SetResult(response);
            }

            IResponse ret;
            try
            {
                cancellationToken?.Add(CancelAction);
                ret = await rpcInfo.Tcs.Task;
            }
            finally
            {
                cancellationToken?.Remove(CancelAction);
            }

            return ret;
        }

        public async ETTask<IResponse> Call(IRequest request)
        {
            int rpcId = ++RpcId;
            RpcInfo rpcInfo = new RpcInfo(request);
            requestCallbacks[rpcId] = rpcInfo;
            request.RpcId = rpcId;
            Send(request);
            return await rpcInfo.Tcs.Task;
        }

        public void Reply(IResponse message)
        {
            Send(message);
        }

        public void Send(IMessage message)
        {
            switch (AService.ServiceType)
            {
                case ServiceType.Inner:
                {
                    (ushort opcode, MemoryStream stream) = MessageSerializeHelper.MessageToStream(0, message);
                    OpcodeHelper.LogMsg(this.DomainZone(), opcode, message);
                    Send(0, stream);
                    break;
                }
                case ServiceType.Outer:
                {
                    (ushort opcode, MemoryStream stream) = MessageSerializeHelper.MessageToStream(message);
                    OpcodeHelper.LogMsg(this.DomainZone(), opcode, message);
                    Send(0, stream);
                    break;
                }
            }
        }

        public void Send(long actorId, IMessage message)
        {
            (ushort opcode, MemoryStream stream) = MessageSerializeHelper.MessageToStream(actorId, message);
            OpcodeHelper.LogMsg(this.DomainZone(), opcode, message);
            Send(actorId, stream);
        }

        public void Send(long actorId, MemoryStream memoryStream)
        {
            LastSendTime = TimeHelper.ClientNow();
            AService.SendStream(Id, actorId, memoryStream);
        }
    }
}