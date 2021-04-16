using Achievement;
using RestaurantPreview.Config;

namespace Client.UI.ViewModel
{
    public class UI_Achievement : UIBase<View_Achievement>
    {
        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            InitUI();
        }

        void InitUI()
        {
            InitList();
        }

        void InitList()
        {
            var analytics = DBManager.Inst.Query<Data_Analytics>();
            foreach (var node in AchievementProperty.ReadDict())
            {
                var value = node.Value;
                var to = value.Target;
                View_ChengJiu1 item;
                if (View.List.GetChild(value.Type) != null)
                    continue;
                if (!PlayerManager.Inst.AchievementList.Contains(node.Key))
                {
                    var cur = analytics.Get(value.Type);
                    item = (View_ChengJiu1) View.List.AddItemFromPool();
                    item.IconPage.selectedIndex = value.Step - 1;
                    item.ProgressBar.value = cur;
                    item.ProgressBar.max = to;
                    for (int i = 0; i < value.Step - 1; i++)
                    {
                        var star = (View_starachievement) item.Star.GetChildAt(i);
                        star.c1.selectedPage = "TRUE";
                    }
                    for (int i = value.Step - 1; i < item.Star.numChildren; i++)
                    {
                        var star = (View_starachievement) item.Star.GetChildAt(i);
                        star.c1.selectedPage = "FALSE";
                    }

                    item.State.selectedPage = cur > to? "待领取" : "未完成";
                }
                else
                {
                    if (!string.IsNullOrEmpty(node.Value.NextStep))
                        continue;
                    item = (View_ChengJiu1) View.List.AddItemFromPool();
                    for (int i = 0; i < item.Star.numChildren; i++)
                    {
                        var star = (View_starachievement) item.Star.GetChildAt(i);
                        star.c1.selectedPage = "TRUE";
                    }
                    item.State.selectedPage = "完成成就";
                }
                item.text = LocalizationProperty.Read(value.Name);
                item.Desc.text = string.Format(LocalizationProperty.Read(value.Desc), to.ToString("N"));
                item.data = value;
                item.name = value.Type;
                item.Finish.onClick.Set(Receive_OnClick);
            }
        }

        private void Receive_OnClick()
        {
            //TODO 领取成就
        }
    }
}