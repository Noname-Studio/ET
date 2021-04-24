using Agones;

namespace ET.ThirdParty
{
    public class AgonesComponentAwakeSystem : AwakeSystem<AgonesComponent,AgonesSDK>
    {
        public override void Awake(AgonesComponent self, AgonesSDK a)
        {
            self.SDK = a;
            var timer = Game.Scene.GetComponent<TimerComponent>();
            self.HealthId = timer.NewRepeatedTimer(5000, self.HealthCheck);
        }
    }

    public class AgonesComponentDestorySystem: DestroySystem<AgonesComponent>
    {
        public override void Destroy(AgonesComponent self)
        {
            TimerComponent.Instance.Remove(self.HealthId);
            self.SDK.ShutDownAsync();
        }
    }
}