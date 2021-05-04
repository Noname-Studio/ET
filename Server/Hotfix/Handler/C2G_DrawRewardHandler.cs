using System;
using System.Collections.Generic;
using RestaurantPreview.Config;

namespace ET
{
    public class C2G_DrawRewardHandler : AMRpcHandler<C2G_DrawReward,G2C_DrawReward>
    {
        protected override async ETTask Run(Session session, C2G_DrawReward request, G2C_DrawReward response, Action reply)
        {
            if (request.Type == 1)
            {
                var list = DrawReward_FriendPointProperty.ReadList();
                List<DrawReward_FriendPointProperty> counting = MathUtils.WeightMath(list, t1 => t1.Weight, 1);
                response.Reward = counting[0].Item;
                response.Number = counting[0].Number;
            }
            reply();
            await ETTask.CompletedTask;
        }
    }
}