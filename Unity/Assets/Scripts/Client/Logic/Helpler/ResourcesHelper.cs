using Client.UI.ViewModel;
using RestaurantPreview.Config;

namespace UnityEngine.Experimental.Rendering.Client.Logic.Helpler
{
    /// <summary>
    /// 所有消耗和获得资源都应该走这个方法去执行
    /// </summary>
    public static class ResourcesHelper
    {
        public static int GetCoin(RestaurantKey rest = null)
        {
            if(rest == null)
                rest = RestaurantKey.This;
            var gameRecord = DBManager.Inst.Query<Data_GameRecord>();
            var coins = gameRecord.Coin;
            return coins;
        }

        public static int GetGem()
        {
            var gameRecord = DBManager.Inst.Query<Data_GameRecord>();
            return gameRecord.Gem;
        }

        public static void SetGameCoin(int count)
        {
            var gameRecord = DBManager.Inst.Query<Data_GameRecord>();
            var coins = gameRecord.Coin;
            if (count > coins)
                GainGameCoin(count - coins);
            else if (count < coins)
                SpenGameCoin(coins - count);
        }
        
        public static void GainGameCoin(int count)
        {
            if(count == 0) return;
            var gameRecord = DBManager.Inst.Query<Data_GameRecord>();
            gameRecord.Coin += count;
            MessageKit.Inst.Send(EventKey.GainGameCoin);
        }

        public static bool SpenGameCoin(int count)
        {
            if(count == 0) return true;
            var gameRecord = DBManager.Inst.Query<Data_GameRecord>();
            if (gameRecord.Coin - count < 0)
            {
                var tips = UIKit.Inst.Create<UI_Tips>();
                tips.AddButton(LocalizationProperty.Read("Confirm"));
                tips.SetContent("这里应该使用特殊的提示面板用于显示和跳转金币的相关获取渠道.");
                return false;
            }
            gameRecord.Coin = Mathf.Max(0, gameRecord.Coin - count);
            MessageKit.Inst.Send(EventKey.SpentGameCoin);
            return true;
        }
        
        public static void GainGem(int count)
        {
            if(count == 0) return;
            var gameRecord = DBManager.Inst.Query<Data_GameRecord>();
            gameRecord.Gem += count;
            MessageKit.Inst.Send(EventKey.GainGem);
        }

        public static bool SpenGem(int count)
        {
            if(count == 0) return true;
            var gameRecord = DBManager.Inst.Query<Data_GameRecord>();
            if (gameRecord.Gem - count < 0)
            {
                var tips = UIKit.Inst.Create<UI_Tips>();
                tips.AddButton(LocalizationProperty.Read("Confirm"));
                tips.SetContent("这里应该使用特殊的提示面板用于显示和跳转点券的相关获取渠道.");
                return false;
            }
            gameRecord.Gem = Mathf.Max(0, gameRecord.Gem - count);
            MessageKit.Inst.Send(EventKey.SpentGem);
            return true;
        }
        
        public static void SetGem(int count)
        {
            var gameRecord = DBManager.Inst.Query<Data_GameRecord>();
            var gem = gameRecord.Gem;
            if (count > gem)
                GainGem(count - gem);
            else if (count < gem)
                SpenGem(gem - count);
        }
    }
}