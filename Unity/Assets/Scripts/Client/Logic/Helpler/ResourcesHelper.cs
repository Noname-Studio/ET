using Client.Event;
using Client.UI.ViewModel;
using RestaurantPreview.Config;

namespace UnityEngine.Experimental.Rendering.Client.Logic.Helpler
{
    /// <summary>
    /// 所有消耗和获得资源都应该走这个方法去执行
    /// </summary>
    public static class ResourcesHelper
    {
        public static bool SpenPrice(Price price,bool updateDB = true)
        {
            if (price.IsFree())
            {
                return true;
            }

            if (price.Coin > 0)
            {
                return SpenGameCoin(price.Coin,updateDB);
            }
            else if (price.Gem > 0)
            {
                return SpenGem(price.Gem,updateDB);
            }

            return false;
        }

        public static int GetCoin(RestaurantKey rest = null)
        {
            if (rest == null)
            {
                rest = RestaurantKey.This;
            }

            var gameRecord = DBManager.Inst.Query<Data_GameRecord>();
            var coins = gameRecord.Coin;
            return coins;
        }

        public static int GetGem()
        {
            var gameRecord = DBManager.Inst.Query<Data_GameRecord>();
            return gameRecord.Gem;
        }

        public static void SetGameCoin(int count,bool updateDB = true)
        {
            var gameRecord = DBManager.Inst.Query<Data_GameRecord>();
            var coins = gameRecord.Coin;
            if (count > coins)
            {
                GainGameCoin(count - coins,updateDB);
            }
            else if (count < coins)
            {
                SpenGameCoin(coins - count,updateDB);
            }
        }

        public static void GainGameCoin(int count,bool updateDB = true)
        {
            if (count == 0)
            {
                return;
            }

            var gameRecord = DBManager.Inst.Query<Data_GameRecord>();
            int temp = gameRecord.Coin;
            gameRecord.Coin += count;
            MessageKit.Inst.Send(EventKey.GainGameCoin);
            MessageKit.Inst.Send(new CoinChanged(temp,gameRecord.Coin));
            if(updateDB)
                DBManager.Inst.Update(gameRecord);
        }

        public static bool SpenGameCoin(int count,bool updateDB = true)
        {
            if (count == 0)
            {
                return true;
            }

            var gameRecord = DBManager.Inst.Query<Data_GameRecord>();
            if (gameRecord.Coin - count < 0)
            {
                var tips = UIKit.Inst.Create<UI_Tips>();
                tips.AddButton(LocalizationProperty.Read("Confirm"));
                tips.SetContent("这里应该使用特殊的提示面板用于显示和跳转金币的相关获取渠道.");
                return false;
            }

            int temp = gameRecord.Coin;
            gameRecord.Coin = Mathf.Max(0, gameRecord.Coin - count);
            MessageKit.Inst.Send(EventKey.SpentGameCoin);
            MessageKit.Inst.Send(new CoinChanged(temp,gameRecord.Coin));
            if(updateDB)
                DBManager.Inst.Update(gameRecord);
            return true;
        }

        public static void GainGem(int count,bool updateDB = true)
        {
            if (count == 0)
            {
                return;
            }

            var gameRecord = DBManager.Inst.Query<Data_GameRecord>();
            int temp = gameRecord.Gem;
            gameRecord.Gem += count;
            MessageKit.Inst.Send(EventKey.GainGem);
            MessageKit.Inst.Send(new GemChanged(temp,gameRecord.Gem));
            if(updateDB)
                DBManager.Inst.Update(gameRecord);
        }

        public static bool SpenGem(int count, bool updateDB = true)
        {
            if (count == 0)
            {
                return true;
            }

            var gameRecord = DBManager.Inst.Query<Data_GameRecord>();
            if (gameRecord.Gem - count < 0)
            {
                var tips = UIKit.Inst.Create<UI_Tips>();
                tips.AddButton(LocalizationProperty.Read("Confirm"));
                tips.SetContent("这里应该使用特殊的提示面板用于显示和跳转点券的相关获取渠道.");
                return false;
            }

            int temp = gameRecord.Gem;
            gameRecord.Gem = Mathf.Max(0, gameRecord.Gem - count);
            MessageKit.Inst.Send(EventKey.SpentGem);
            MessageKit.Inst.Send(new GemChanged(temp,gameRecord.Gem));
            if(updateDB)
                DBManager.Inst.Update(gameRecord);
            return true;
        }

        public static void SetGem(int count,bool updateDB = true)
        {
            var gameRecord = DBManager.Inst.Query<Data_GameRecord>();
            var gem = gameRecord.Gem;
            if (count > gem)
            {
                GainGem(count - gem,updateDB);
            }
            else if (count < gem)
            {
                SpenGem(gem - count,updateDB);
            }
        }
    }
}