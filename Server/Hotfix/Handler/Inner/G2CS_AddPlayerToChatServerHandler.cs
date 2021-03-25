using System;

namespace ET
{
    public class G2CS_AddPlayerToChatServerHandler : AMActorRpcHandler<Scene, G2CS_AddPlayerToChatServer, CS2G_AddPlayerToChatServer>
    {
        protected override async ETTask Run(Scene scene, G2M_CreateUnit request, M2G_CreateUnit response, Action reply)
        {
            ChatUnit unit = EntityFactory.CreateWithId<ChatUnit>(scene, IdGenerater.Instance.GenerateId());
            unit.AddComponent<MailBoxComponent>();
            await unit.AddLocation();
            unit.AddComponent<UnitGateComponent, long>(request.GateSessionId);
            scene.GetComponent<ChatUnitComponent>().Add(unit);
            response.UnitId = unit.Id;
            reply();
        }
    }
}