using Client.UI.ViewModel;
using RestaurantPreview.Config;

public static class EnterLevelHelper
{
    public static bool CheckCondition()
    {
        if (EnergyManager.Inst.CurEnergy < GlobalConfigProperty.Read("LevelConsumeEnergy").Int)
        {
            var tips = UIKit.Inst.Create<UI_NoEnergyTips>();
            return false;
        }

        return true;
    }
}