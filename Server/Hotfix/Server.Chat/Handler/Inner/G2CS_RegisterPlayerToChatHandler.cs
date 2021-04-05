using System;
using ET.Server.Chat;
using ET.Server.Chat.Component;

namespace ET
{
    [ActorMessageHandler]
    public class G2CS_RegisterPlayerToChatHandler : AMActorRpcHandler<Scene, G2CS_RegisterPlayerToChat, CS2G_RegisterPlayerToChat>
    {
        protected override async ETTask Run(Scene scene, G2CS_RegisterPlayerToChat request, CS2G_RegisterPlayerToChat response, Action reply)
        {
            var chatUnitComponent = scene.GetComponent<ChatUnitComponent>();
            ChatUnit unit = chatUnitComponent.Get(request.ChatId);
            if (unit == null || request.ChatId == 0)
            {
                unit = EntityFactory.CreateWithId<ChatUnit>(scene, IdGenerater.Instance.GenerateId());
                unit.AddComponent<MailBoxComponent>();
                await unit.AddLocation();
                unit.GateSessionId = request.GateSessionId;
                scene.GetComponent<ChatUnitComponent>().Add(unit);
                unit.Scene = scene;
                unit.PlayerId = request.PlayerId;
            }
            unit.Head = request.Head;
            unit.Name = request.Name;
            response.UnitId = unit.Id;
            reply();
        }
    }
}