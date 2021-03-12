namespace ET
{
    [ActorMessageHandler]
    public class M2C_GuildUpdateHandler : AMActorLocationHandler<Unit, M2C_GuildUpdate>
    {
        protected override async ETTask Run(Unit entity, M2C_GuildUpdate message)
        {
            UnitGateComponent unitGateComponent = entity.GetComponent<UnitGateComponent>();
            MessageHelper.SendActor(unitGateComponent.GateSessionActorId, message);
            await ETTask.CompletedTask;
        }
    }
}