using System.Linq;

namespace ET
{
    public class Data_GuildComponentSystem : AwakeSystem<GuildComponent,ETTaskCompletionSource>
    {
        public override void Awake(GuildComponent self,ETTaskCompletionSource tcs)
        {
            self.Awake();
            TimerComponent.Instance.NewRepeatedTimer(1800000, self.Update);
            /*var list = await DBComponent.Instance.Query<Data_Guild>(t1=>t1.Id > 0);
            foreach (var node in list)
            {
                self.Add(node, false);
            }*/
            tcs.SetResult();
        }
    }
    public static class GuildComponentHelper
    {
        public static async void Update(this GuildComponent self)
        {
            var list = self.dirty.Values.ToList();
            await DBComponent.Instance.Save(RandomHelper.RandInt64(), list);
        }
    }
}