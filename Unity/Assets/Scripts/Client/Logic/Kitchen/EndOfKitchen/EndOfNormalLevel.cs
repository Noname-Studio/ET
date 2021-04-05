using Client.UI.ViewModel;
using Cysharp.Threading.Tasks;
using Kitchen;
using Kitchen.Action;
using UnityEngine;
using UnityEngine.Analytics;

/// <summary>
/// 普通关卡游戏结束处理类
/// </summary>
public class EndOfNormalLevel: IEndExecute
{
    private LevelProperty LevelProperty { get; }
    private PlayerController PlayerController { get; }

    public EndOfNormalLevel(LevelProperty property, PlayerController playerController)
    {
        LevelProperty = property;
        PlayerController = playerController;
    }

    public void Execute(KitchenEndState state)
    {
        if (state == KitchenEndState.Fail)
        {
            Fail();
        }
        else if (state == KitchenEndState.Win)
        {
            Complete();
        }
        else if (state == KitchenEndState.Restart)
        {
            Restart();
        }
    }

    private void Fail()
    {
        Log.Print("通关失败");
        AnalyticsEvent.LevelFail(LevelProperty.RestaurantId.Key, LevelProperty.LevelId);
        QueueEventsKit.Inst.Clear();
        QueueEventsKit.Inst.AddToBottom(new PauseKitchenLogic());
        QueueEventsKit.Inst.AddToBottom(new MakeAllCustomersLeave());
        QueueEventsKit.Inst.AddToBottom(new PlayAnimation(PlayerController, "Lose", true));
        QueueEventsKit.Inst.AddToBottom(new CreateUI<UI_NormalLevelFail>());
    }

    private void Complete()
    {
        Log.Print("通关成功");
        AnalyticsEvent.LevelComplete(LevelProperty.RestaurantId.Key, LevelProperty.LevelId);
        QueueEventsKit.Inst.Clear();
        QueueEventsKit.Inst.AddToBottom(new PauseKitchenLogic());
        QueueEventsKit.Inst.AddToBottom(new MakeAllCustomersLeave());
        QueueEventsKit.Inst.AddToBottom(new PlayAnimation(PlayerController, "Win", true));
        QueueEventsKit.Inst.AddToBottom(new CreateUI<UI_NormalLevelWin>());
    }

    private async void Restart()
    {
        Log.Print("重新开始关卡"); 
        AnalyticsEvent.LevelFail(LevelProperty.RestaurantId.Key, LevelProperty.LevelId);
        QueueEventsKit.Inst.Clear();
        QueueEventsKit.Inst.AddToBottom(new PauseKitchenLogic());
        QueueEventsKit.Inst.AddToBottom(new MakeAllCustomersLeave());
        QueueEventsKit.Inst.AddToBottom(new PlayAnimation(PlayerController, "Lose", true));
        QueueEventsKit.Inst.AddToBottom(new ResetKitchen());
        QueueEventsKit.Inst.AddToBottom(new CreateUI<UI_EnterLevelPanel>());
    }
}