using Kitchen;
using UnityEngine;
using UnityEngine.Analytics;

/// <summary>
/// 普通关卡游戏结束处理类
/// </summary>
public class EndOfNormalLevel : IEndExecute
{
    private LevelProperty LevelProperty { get; }
    private PlayerController PlayerController { get; }
    public EndOfNormalLevel(LevelProperty property,PlayerController playerController)
    {
        LevelProperty = property;
        PlayerController = playerController;
    }
    
    public void Execute(bool win)
    {
        if (win == false)
            Fail();
        else
            Complete();
    }

    private void Fail()
    {
        Log.Print("通关失败");
        //AnalyticsEvent.LevelFail(LevelProperty.RestaurantId.Key, LevelProperty.LevelId);
        PlayerController.Animator.Play("");
    }

    private void Complete()
    {
        Log.Print("通关成功");
        //AnalyticsEvent.LevelComplete(LevelProperty.RestaurantId.Key, LevelProperty.LevelId);
        
    }
}
