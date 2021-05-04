using System;
using System.Collections;
using System.Collections.Generic;
using Client.Effect;
using Common;
using FairyGUI;
using RestaurantPreview.Config;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Client.Logic.Helpler;

[UIWindow(Enter = WindowAnimType.Fall,Exit = WindowAnimType.Rise,Background = true)]
public class UI_PropRewardTips : UIBase<View_tipsprop>
{
    public string Title
    {
        get
        {
            return View.title;
        }
        set
        {
            View.text = value;
        }
    }

    public class UIParamsData : IUIParams
    {
        public Dictionary<string,int> Items;

        public UIParamsData(Dictionary<string,int> items)
        {
            Items = items;
        }
    }

    private UIParamsData Args { get; set; }
    protected override void OnInit(IUIParams p)
    {
        base.OnInit(p);
        Args = p as UIParamsData;
        if (Args == null)
        {
            Log.Error("参数错误");
            CloseMySelf();
            return;
        }
        View.Confirm.onClick.Set(Confirm_OnClick);
        InitList();
    }

    private void Confirm_OnClick()
    {
        CloseMySelf();
    }

    private void InitList()
    {
        foreach (var node in Args.Items)
        {
            var prop = PropProperty.Read(node.Key);
            if (prop == null)
            {
                Log.Error("找不到物品ID" + node.Key);
                continue;
            }

            var item = (GLabel)View.PropList.AddItemFromPool();
            item.icon = prop.Icon;
            if (node.Key == GameConfig.InfiniteEnergyPropKey)
            {
                var time = TimeSpan.FromSeconds(node.Value);
                item.text = time.ToString(time.Hours > 0? @"h\h\:m\m" : @"m\m");
            }
            else
            {
                item.text = "x" + node.Value;
            }
        }
    }

    public static void Pop(Dictionary<string,int> content)
    {
        foreach (var node in content)
        {
            var prop = PropProperty.Read(node.Key);
            if (prop == null)
            {
                Log.Error("内容中存在不存在的物品内容" + "不存在的物品ID:" + node.Key);
                continue;
            }
        
            if (prop.Type == PropProperty.TypeEnum.Level || prop.Type == PropProperty.TypeEnum.InTheLevel )
            {
                DBManager.Inst.Query<Data_Prop>().Get(prop.Id).Count += node.Value;
            }
        
            if (prop.Id == GameConfig.InfiniteEnergyPropKey)
            {
                EnergyManager.Inst.AddInfineTime(node.Value);
            }
            else if (prop.Id == GameConfig.GemPropKey)
            {
                ResourcesHelper.GainGem(node.Value);
                EffectFactory.Create(new ResourcesBarValueChanged(node.Value, ResourcesBarValueChanged.ResourceType.Gem));
            }
            else if (prop.Id == GameConfig.CoinPropKey)
            {
                ResourcesHelper.GainGameCoin(node.Value);
                EffectFactory.Create(new ResourcesBarValueChanged(node.Value, ResourcesBarValueChanged.ResourceType.Coin));
            }
        }
        
        UIKit.Inst.Create<UI_PropRewardTips>(new UIParamsData(content));
    }
}
