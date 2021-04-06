using System;
using Model.Module.DB.ActualTable;

namespace ET
{
    public static class CacheHelper
    {
        public static async ETTask<T> Get<T>(long id) where T : Entity
        {
            var type = typeof (T);
            if (type == typeof (Data_PlayerInfo))
            {
                var player = PlayerComponent.Instance.Get(id);
                if (player == null)
                {
                    return await Internal_Get<T>(id);
                }
                return player as T;
            }
            else if (type == typeof (Data_Guild))
            {
                var guild = GuildComponent.Instance.Get(id);
                if (guild == null)
                {
                    return await Internal_Get<T>(id);
                }
                return guild as T;
            }
            else
                return await Internal_Get<T>(id);
        }

        public static async ETTask Set<T>(long id, Func<T,T> setter) where T: Entity
        {
            var type = typeof (T);
            if (type == typeof (Data_PlayerInfo))
            {
                var player = PlayerComponent.Instance.Get(id);
                if (player == null)
                {
                    await Internal_Set(id, setter);
                }
                else
                {
                    setter(player as T);
                }
            }
            else if (type == typeof (Data_Guild))
            {
                var guild = GuildComponent.Instance.Get(id);
                if (guild == null)
                {
                    await Internal_Set(id, setter);
                }
                else
                {
                    setter(guild as T);
                }
            }
            else
                await Internal_Set(id, setter);
        }

        private static async ETTask<T> Internal_Get<T>(long id) where T : Entity
        {
            var result = await DBComponent.Instance.Query<T>(id);
            return result;
        }

        private static async ETTask Internal_Set<T>(long id,Func<T,T> setter) where T : Entity
        {
            var getter = await Internal_Get<T>(id);
            var result = setter(getter);
            RedisComponent.Instance.Set(result);
        }
    }
}