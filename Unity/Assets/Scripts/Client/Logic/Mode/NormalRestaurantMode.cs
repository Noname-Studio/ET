using System;
using Client.UI.ViewModel;
using Cysharp.Threading.Tasks;

public class NormalRestaurantMode: IRestaurantMode
{
    public UniTask Enter()
    {
        CreateUI();
        return UniTask.CompletedTask;
    }

    public UniTask Exit()
    {
        UIKit.Inst.UnLoadAllUI();
        return UniTask.CompletedTask;
    }

    private void CreateUI()
    {
        UIKit.Inst.Create<UI_RestaurantMain>();
    }
}