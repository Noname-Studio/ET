using System;
using Client.UI.ViewModel;
using Cysharp.Threading.Tasks;

public class NormalRestaurantMode : IRestaurantMode
{
    public async UniTask Enter()
    {
        CreateUI();
    }

    private void CreateUI()
    {
        UIKit.Inst.Create<UI_RestaurantMain>();
    }
    
    public UniTask Exit()
    {
        throw new NotSupportedException();
    }
}
