using System.Collections.Generic;
using System.ComponentModel;
using FairyGUI;
using GamingUI;
using Kitchen;
using RestaurantPreview.Config;
using UnityEngine;

namespace Client.UI.ViewModel
{
    public class UI_KitchenMain: UIBase<View_KitchenMain>
    {
        private LevelProperty LevelProperty { get; }
        private Com_TimeBar TimeBar { get; set; }
        private KitchenRecord Record { get; } = KitchenRoot.Inst.Record;

        public UI_KitchenMain()
        {
            LevelProperty = KitchenRoot.Inst.LevelProperty;
        }

        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            if (LevelProperty.LevelType.HasFlag(LevelProperty.LevelTypeFlags.固定时间))
            {
                TimeBar = new Com_TimeBar(View.TimeBar);
                TimeBar.Max = TimeBar.Value = LevelProperty.Requirements.FixedTime;
                TimeBar.ValueChangedCallback += (d, bar) =>
                {
                    if (bar is View_timerBar b && !b.t0.playing)
                    {
                        if (d < 15)
                        {
                            b.t0.Play();
                        }
                    }
                };
            }
            else
            {
                View.TimeBar.visible = false;
            }

            KitchenRoot.Inst.Record.PropertyChanged += RecordChanged;
            RegisterButtonClick();
        }

        private void RecordChanged(object sender, PropertyChangedEventArgs e)
        {
            if (LevelProperty.LevelType.HasFlag(LevelProperty.LevelTypeFlags.点赞数量))
            {
                View.ScoreBar.value = Record.LikeCount;
            }
            else if (LevelProperty.LevelType.HasFlag(LevelProperty.LevelTypeFlags.服务订单))
            {
                View.ScoreBar.value = Record.ServicesOrderNumber;
            }
            else if (LevelProperty.LevelType.HasFlag(LevelProperty.LevelTypeFlags.服务顾客))
            {
                View.ScoreBar.value = Record.ServicesCustomerNumber;
            }
            else if (LevelProperty.LevelType.HasFlag(LevelProperty.LevelTypeFlags.收集金币))
            {
                View.ScoreBar.value = Record.CoinNumber;
            }
        }

        protected override void OnEnable(IUIParams p, bool refresh)
        {
            InitCondition();
            InitRequirement();
        }

        /// <summary>
        /// 注册所有按钮的点击事件
        /// </summary>
        private void RegisterButtonClick()
        {
            View.Pause.onClick.Add(Pause_OnClick);
        }

        private void Pause_OnClick(EventContext context)
        {
            UIKit.Inst.Create<UI_KitchenPause>();
        }

        /// <summary>
        /// 初始化通关目标
        /// </summary>
        private void InitRequirement()
        {
            var req = LevelProperty.Requirements;
            if (LevelProperty.LevelType.HasFlag(LevelProperty.LevelTypeFlags.固定时间))
            {
                View.TimeBar.max = req.FixedTime;
            }

            if (LevelProperty.LevelType.HasFlag(LevelProperty.LevelTypeFlags.点赞数量))
            {
                View.ScoreBar.c1.selectedPage = "Praise";
                View.ScoreBar.max = req.LikeCount;
            }

            if (LevelProperty.LevelType.HasFlag(LevelProperty.LevelTypeFlags.服务订单))
            {
                View.ScoreBar.c1.selectedPage = "Foods";
                View.ScoreBar.max = req.NumberOfCompletedOrders;
            }

            if (LevelProperty.LevelType.HasFlag(LevelProperty.LevelTypeFlags.收集金币))
            {
                View.ScoreBar.c1.selectedPage = "Coin";
                View.ScoreBar.max = req.RequiredCoin;
            }

            if (LevelProperty.LevelType.HasFlag(LevelProperty.LevelTypeFlags.服务顾客))
            {
                View.ScoreBar.c1.selectedPage = "Foods";
                View.ScoreBar.max = req.NumberOfCustomerService;
            }
            View.ScoreBar.value = 0;
        }

        /// <summary>
        /// 初始化关卡条件
        /// </summary>
        private void InitCondition()
        {
            int i = 0;
            var req = LevelProperty.Requirements;
            if (!req.AllowBurn)
            {
                var loader = View.Condition.GetChildAt(i++).asLoader;
                loader.url = "ui://Common/no_burn";
            }

            if (!req.AllowUseTrash)
            {
                var loader = View.Condition.GetChildAt(i++).asLoader;
                loader.url = "ui://Common/no_trash";
            }

            if (!req.AllowLostCustomer)
            {
                var loader = View.Condition.GetChildAt(i++).asLoader;
                loader.url = "ui://Common/icon_no_lost";
            }

            View.Condition.c1.selectedIndex = i;
        }

        /// <summary>
        /// 展示菜品制作流程
        /// </summary>
        public void ShowFoodProcess(FoodProperty foodProperty)
        {
            /*View.TipBar.RemoveAll();
            List<string> iconList = new List<string>();
            foreach (var node in foodProperty.AllIngredients)
            {
                if (node.StartsWith("F_"))
                {
                    ShowFoodProcess(node);
                    View.TipBar.Slash();
                }
                else if(node.StartsWith("I_"))
                {
                    var prop = KitchenDataHelper.LoadIngredient(node);
                    iconList.Add(prop.Texture);
                }
            }

            var cookware = KitchenDataHelper.LoadCookware(foodProperty.Cookware).Current.Texture;
        
            var result = foodProperty.Texture;

            if (iconList.Count == 0)
            {
                View.TipBar.To(cookware, result);
            }
            else
            {
                View.TipBar.Plus(iconList, cookware).Equal(result);
            }*/
        }

        /// <summary>
        /// 展示菜品制作流程
        /// </summary>
        public void ShowFoodProcess(string key)
        {
            var foodProperty = FoodProperty.Read(key);
            ShowFoodProcess(foodProperty);
        }

        public override void Update()
        {
            View.ComboBar.Update();
            TimeBar?.Update(Mathf.CeilToInt(LevelProperty.Requirements.FixedTime - Record.PlayTime));
        }
    }
}