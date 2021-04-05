using FairyGUI;
using GamingUI;

namespace Client.UI.ViewModel
{
    [UIWidget(Pool = true, Repeat = true)]
    public class UI_PatienceProgress: UIBase<View_PatienceProgress>
    {
        public float Value
        {
            set
            {
                GTween.To(View.Bar.fillAmount, value / 100f, 0.5f).SetTarget(View.Bar);
                View.Bar.fillAmount = value / 100f;
                if (value > 60)
                {
                    View.State.selectedPage = "Normal";
                }
                else if (value > 30)
                {
                    View.State.selectedPage = "Impatient";
                }
                else
                {
                    View.State.selectedPage = "Angry";
                }
            }
            get => View.Bar.fillAmount * 100;
        }
    }
}