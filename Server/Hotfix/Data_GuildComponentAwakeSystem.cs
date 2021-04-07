using System.Linq;

namespace ET
{
    public class Data_GuildComponentAwakeSystem : AwakeSystem<GuildComponent,ETTaskCompletionSource>
    {
        public override async void Awake(GuildComponent self,ETTaskCompletionSource tcs)
        {
            self.Awake();
            var list = await DBComponent.Instance.Query<Data_Guild>(t1=>t1.Id > 0);
            foreach (var node in list)
            {
                self.Add(node, false);
            }
            tcs.SetResult();
        }
    }
    
    public class Data_GuildComponentDisposeSystem : DestroySystem<GuildComponent>
    {
        public override void Destroy(GuildComponent self)
        {
            self.Update();
        }
    }
    
    public static class GuildComponentHelper
    {
        public static async void Update(this GuildComponent self)
        {
            var list = self.dirty.Values.ToList();
            Log.Info("保存公会数据");
            await DBComponent.Instance.Save(RandomHelper.RandInt64(), list);
        }
        
        public static void MarkDirty(this GuildComponent self, Data_Guild guild)
        {
            self.dirty[guild.Id] = guild;
        }

        public static void Add(this GuildComponent self, Data_Guild guildInfo,bool markDirty = true)
        {
            self.guilds[guildInfo.Id] = guildInfo;
            if(markDirty)
                self.MarkDirty(guildInfo);
        }

        public static async ETTask RegisterAllGuildToChat(this GuildComponent self)
        {
            long ChatServerId = StartSceneConfigCategory.Instance.GetBySceneName(1, "Chat").SceneId;
            foreach (var node in self.guilds)
            {
                await ActorMessageSenderComponent.Instance.Call(ChatServerId, new G2CS_AddGuildToChatServer() { GuildId = node.Value.Id });
            }
        }

        public static async ETTask RegisterGuildToChat(this GuildComponent self, Data_Guild guild)
        {
            long ChatServerId = StartSceneConfigCategory.Instance.GetBySceneName(1, "Chat").SceneId;
            await ActorMessageSenderComponent.Instance.Call(ChatServerId, new G2CS_AddGuildToChatServer() { GuildId = guild.Id });
        }
        
        public static Data_Guild Get(this GuildComponent self,long id)
        {
            self.guilds.TryGetValue(id, out Data_Guild gamer);
            return gamer;
        }

        public static void Remove(this GuildComponent self,long id)
        {
            self.guilds.Remove(id);
        }

        public static Data_Guild[] GetAll(this GuildComponent self)
        {
            return self.guilds.Values.ToArray();
        }
    }
}