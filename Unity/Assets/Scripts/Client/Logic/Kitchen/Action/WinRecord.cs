namespace Kitchen.Action
{
    public class WinRecord : IGameAction
    {
        public void Execute()
        {
            var analytics = DBManager.Inst.Query<Data_Analytics>();
            var game = DBManager.Inst.Query<Data_GameRecord>();
            var record = KitchenRoot.Inst.Record;
            analytics.Combo3 += record.Combo3;
            analytics.Combo4 += record.Combo4;
            analytics.CoinNumber += record.CoinNumber;
            analytics.LikeCount += record.LikeCount;
            analytics.TipsNumber += record.TipsNumber;
            analytics.BurnFoodCount += record.BurnFoodCount;
            analytics.LostCustomerCount += record.LostCustomerCount;
            analytics.ServicesCustomerNumber += record.ServicesCustomerNumber;
            analytics.ServicesOrderNumber += record.ServicesOrderNumber;
            analytics.PlayTime += record.PlayTime;
            if (record.BurnFoodCount > 0)
            {
                analytics.ConsecutiveLevels.BurnFoodCount = 0;
            }
            else
            {
                analytics.ConsecutiveLevels.BurnFoodCount += 1;
                if (analytics.ConsecutiveLevels.BurnFoodCount > analytics.ConsecutiveLevels.TotalBurnFoodCount)
                    analytics.ConsecutiveLevels.TotalBurnFoodCount = analytics.ConsecutiveLevels.BurnFoodCount;
            }
            if (record.LostCustomerCount > 0)
            {
                analytics.ConsecutiveLevels.LostCustomerCount = 0;
            }
            else
            {
                analytics.ConsecutiveLevels.LostCustomerCount += 1;
                if (analytics.ConsecutiveLevels.LostCustomerCount > analytics.ConsecutiveLevels.TotalLostCustomerCount)
                    analytics.ConsecutiveLevels.TotalLostCustomerCount = analytics.ConsecutiveLevels.LostCustomerCount;
            }
            if (record.DropFoodCount > 0)
            {
                analytics.ConsecutiveLevels.DropFoodCount = 0;
            }
            else
            {
                analytics.ConsecutiveLevels.DropFoodCount += 1;
                if (analytics.ConsecutiveLevels.DropFoodCount > analytics.ConsecutiveLevels.TotalDropFoodCount)
                    analytics.ConsecutiveLevels.TotalDropFoodCount = analytics.ConsecutiveLevels.DropFoodCount;
            }

            analytics.ConsecutiveLevels.Level += 1;
            if (analytics.ConsecutiveLevels.Level > analytics.ConsecutiveLevels.TotalLevel)
                analytics.ConsecutiveLevels.TotalLevel = analytics.ConsecutiveLevels.Level;
            game.Level[KitchenRoot.Inst.LevelProperty.Restaurant.Key] = KitchenRoot.Inst.LevelProperty.Id + 1;
            DBManager.Inst.Update(game);
            DBManager.Inst.Update(analytics);
        }

        public bool Update()
        {
            return true;
        }
    }
}