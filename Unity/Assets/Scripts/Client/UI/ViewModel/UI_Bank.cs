using System;
using System.Collections.Generic;
using Bank;
using Client.Effect;
using FairyGUI;
using Panthea.NativePlugins.Ads;
using Panthea.NativePlugins.Analytics;
using Panthea.NativePlugins.IAP;
using RestaurantPreview.Config;
using UnityEngine.Analytics;
using UnityEngine.Experimental.Rendering.Client.Logic.Helpler;

public class UI_Bank : UIBase<View_BankNew>
{
    private int WatchVideoGetGemNum { get; set; }
    protected override void OnInit(IUIParams p)
    {
        base.OnInit(p);
        WatchVideoGetGemNum = GlobalConfigProperty.Read("WatchVideoGetGemNum").Int;
        InitUI();
    }

    private void InitUI()
    {
        View.Page.onChanged.Add(Controller_PageChanged);
        Controller_PageChanged();
    }

    private void Controller_PageChanged()
    {
        if (View.Page.selectedPage == "Diamond")
        {
            InitDiamondList();
            View.List.onClickItem.Set(List_ClickDiamondItem);
        }
        else if (View.Page.selectedPage == "Gift")
        {
            InitPackList();
            View.List.onClickItem.Set(List_ClickPackItem);
        }
        else if (View.Page.selectedPage == "Prop")
        {
            InitPropList();
            View.List.onClickItem.Set(List_ClickPropItem);
        }

        View.List.selectedIndex = 0;
        View.List.onClickItem.Call(View.List.GetChildAt(0));
    }

    public void SetPage(string pageName)
    {
        View.Page.selectedPage = pageName;
    }

    private void InitDiamondList()
    {
        View.List.RemoveChildrenToPool();
        View_CardDiamond item = (View_CardDiamond)View.List.AddItemFromPool(View_CardDiamond.URL);
        item.icon = "ui://Bank/广告入口";
        item.Num.text = "<img src='ui://Common/钻石' width=50' height='50'/> x " + WatchVideoGetGemNum;//每次看广告给2颗钻石
        item.Offer.visible = false;
        item.Buy.text = item.Price.text = LocalizationProperty.Read("FreeToGetGem");
        item.Buy.onClick.Set(AdsButton_OnClick);
        item.ads_effect.Play(-1, 0, null);
        item.data = null;
        foreach (var node in IAPProperty.ReadDict())
        {
            var value = node.Value;
            if (node.Value.Categories == IAPProperty.CategoriesEnum.gem)
            {
                item = (View_CardDiamond)View.List.AddItemFromPool(View_CardDiamond.URL);
                item.data = value;
                item.recommend.visible = value.Recommend;
                item.icon = value.Icon;
                item.Num.text = "<img src='ui://Common/钻石' width=50' height='50'/> x " + node.Value.CurrentNum;
                item.Offer.visible = value.OriginNum != value.CurrentNum;
                item.Additive.text = "+" + (value.CurrentNum - value.OriginNum).ToString();
                item.Price.text = item.Buy.title = IAPKit.Inst.GetLocalizedPriceString(node.Key);
                item.Buy.onClick.Set(Purchase_OnClick);
                item.Buy.data = value;
                if (value.Content.TryGetValue(GameConfig.InfiniteEnergyPropKey, out int count))
                {
                    item.InfineGroup.visible = true;
                    var time = TimeSpan.FromSeconds(count);
                    item.InfineTime.text = time.ToString(time.Hours > 0? @"h\h\:m\m" : @"m\m");
                }
                else
                {
                    item.InfineGroup.visible = false;
                }
            }
        }
    }

    private void InitPackList()
    {
        View.List.RemoveChildrenToPool();
        foreach (var node in IAPProperty.ReadDict())
        {
            var value = node.Value;
            if (node.Value.Categories == IAPProperty.CategoriesEnum.pack)
            {
                var item = (View_CardGift)View.List.AddItemFromPool(View_CardGift.URL);
                item.recommend.visible = value.Recommend;
                item.title = LocalizationProperty.Read(value.Name);
                item.icon = value.Icon + "_icon";
                item.Buy.title = item.Price.text = IAPKit.Inst.GetLocalizedPriceString(node.Key);
                item.data = item.Buy.data = value;
                item.Buy.onClick.Set(Purchase_OnClick);
            }
        }
    }

    private void InitPropList()
    {
        View.List.RemoveChildrenToPool();
        foreach (var node in PropProperty.ReadDict())
        {
            var value = node.Value;
            if (node.Value.Type == PropProperty.TypeEnum.Level || node.Value.Type == PropProperty.TypeEnum.InTheLevel)
            {
                var item = (View_CardProp)View.List.AddItemFromPool(View_CardProp.URL);
                if (PlayerManager.Inst.CurrentLevel < value.Unlock)
                {
                    item.enabled = false;
                    item.Desc.text = LocalizationProperty.Read("Unlock");
                }
                else
                {
                    item.title = LocalizationProperty.Read(value.Name);
                    item.icon = value.Icon;
                    item.Buy.title = item.Desc.text = value.Price.ConvertToString(55, 55);
                    item.data = item.Buy.data = value;
                    item.Num.text = "x 1";
                    item.Buy.onClick.Set(BuyProp_OnClick);
                }
            }
        }
    }

    private void BuyProp_OnClick(EventContext context)
    {
        context.StopPropagation();
        var clicker = (GObject) context.sender;
        var data = (PropProperty)clicker.data;
        if (ResourcesHelper.SpenPrice(data.Price))
        {
            DBManager.Inst.Query<Data_Prop>().Get(data.Id).Count++;
            AnalyticsKit.Inst.StoreItemClick(StoreType.Soft, data.Id, LocalizationProperty.Read(data.Name));
            EffectFactory.Create(new ResourcesBarValueChanged(-data.Price.Gem, ResourcesBarValueChanged.ResourceType.Gem));
            View.List.onClickItem.Call(clicker);
        }
    }

    private void Purchase_OnClick(EventContext context)
    {
        context.StopPropagation();
        var data = (IAPProperty)((GObject) context.sender).data;
        IAPKit.Inst.Purchase(data.Id);
    }

    private async void AdsButton_OnClick(EventContext context)
    {
        context.StopPropagation();
        var adsCallback = await AdsKit.Inst.PlayRewardVideoAsync();
        if (adsCallback.result)
        {
            ResourcesHelper.GainGem(WatchVideoGetGemNum);
            AnalyticsKit.Inst.AdComplete(true, adsCallback.handler.ToString(), "Free Gem");
            EffectFactory.Create(new ResourcesBarValueChanged(WatchVideoGetGemNum, ResourcesBarValueChanged.ResourceType.Gem));
        }
        else
        {
            AnalyticsKit.Inst.AdComplete(false, adsCallback.handler.ToString(), "Free Gem");
        }
    }
    
    private void List_ClickDiamondItem(EventContext context)
    {
        var button = context.data as GButton;
        var property = button.data as IAPProperty;
        if (property == null) //是广告
        {
            View.ItemIcon.url = "ui://Bank/广告入口";
            View.DiamondExt.visible = false;
            View.InfineGroup.visible = false;
            View.ItemName.text = "x " + WatchVideoGetGemNum;
            View.Buy.title = LocalizationProperty.Read("FreeToGetGem");
            View.Buy.onClick.Set(AdsButton_OnClick);
        }
        else
        {
            View.ItemIcon.url = property.Icon;
            var subNum = property.CurrentNum - property.OriginNum;
            View.DiamondExt.visible = subNum > 0;
            View.DiamondExt.title = subNum.ToString();
            View.ItemName.text = "x " + property.CurrentNum;
            View.Buy.data = property;
            View.Buy.title = IAPKit.Inst.GetLocalizedPriceString(property.Id);
            View.Buy.onClick.Set(Purchase_OnClick);
            if (property.Content.TryGetValue(GameConfig.InfiniteEnergyPropKey, out int count))
            {
                View.InfineGroup.visible = true;
                var time = TimeSpan.FromSeconds(count);
                View.InfineTime.text = time.ToString(time.Hours > 0? @"h\h\:m\m" : @"m\m");
            }
            else
            {
                View.InfineGroup.visible = false;
            }
        }
    }
    
    private void List_ClickPackItem(EventContext context)
    {
        var button = context.data as GButton;
        var property = button.data as IAPProperty;    
        View.ItemIcon.url = property.Icon;
        View.ItemName.text = LocalizationProperty.Read(property.Name);
        View.Buy.data = property;
        View.Buy.title = IAPKit.Inst.GetLocalizedPriceString(property.Id);
        View.Buy.onClick.Set(Purchase_OnClick);
        var container = View.Detail;
        int index = 0;
        foreach (var node in property.Content)
        {
            var prop = PropProperty.Read(node.Key);
            container.GetChild("prop" + index + "icon").asLoader.url = prop.Icon;
            container.GetChild("prop" + index + "text").asTextField.text = "x" + node.Value;
            index++;
        }

        container.c1.selectedIndex = index - 1;
        container.packicon.url = property.Icon + "open_icon";
    }
    
    private void List_ClickPropItem(EventContext context)
    {
        var button = context.data as GButton;
        var property = button.data as PropProperty;
        var db = DBManager.Inst.Query<Data_Prop>();
        View.ItemName2.text = LocalizationProperty.Read(property.Name);
        View.ItemDesc.text = LocalizationProperty.Read(property.Desc);
        View.OwnCount.SetVar("count",db.Get(property.Id).Count.ToString()).FlushVars();
        View.ItemIcon.url = property.Icon;
        View.ItemName.text = "x 1";
        View.Buy.data = property;
        View.Buy.title = property.Price.ConvertToString(55, 55);
        View.Buy.onClick.Set(BuyProp_OnClick);
    }
}
