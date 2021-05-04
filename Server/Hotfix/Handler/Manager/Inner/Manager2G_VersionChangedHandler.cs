namespace ET
{
    [ActorMessageHandler]
    public class Manager2G_VersionChangedHandler : AMActorHandler<Scene,Manager2G_VersionChanged>
    {
        protected override async ETTask Run(Scene entity, Manager2G_VersionChanged message)
        {
            var component = entity.GetComponent<PlayerComponent>();
            foreach (var node in component.GetAll())
            {
                MessageHelper.SendToLocationActor(node.UnitId, new G2C_VersionChanged());
            }
            await ETTask.CompletedTask;
        }
    }
}