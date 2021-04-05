using System;
using GamingUI;

namespace Client.UI.ViewModel
{
    [UIWidget(Repeat = true)]
    public class UI_CookwareProgress: UIBase<View_CookwareProgress>
    {
        private CookwareState mState;

        public void SetFill(float value)
        {
            View.Fill.fillAmount = value;
            View.Arrow.rotation = value * 360f; //因为旋转是0-360的,而填充率是0-1的所以要将0-1映射到0-360中
        }

        public void SetState(CookwareState state)
        {
            mState = state;
            View.Fill.fillAmount = 0;
            View.Arrow.rotation = 0;
            View.State.selectedPage = Enum.GetName(typeof (CookwareState), state);
        }

        public override void Update()
        {
            if (mState == CookwareState.Burning)
            {
                if (View.Fill.fillAmount >= 70)
                {
                    PlayWarning();
                }
                else
                {
                    StopWarning();
                }
            }
            else if (mState == CookwareState.Work)
            {
                Visible = true;
            }
            else
            {
                Visible = false;
                StopWarning();
            }
        }

        private void PlayWarning()
        {
            if (!View.Warning.playing)
            {
                View.Warning.Play();
            }
        }

        private void StopWarning()
        {
            if (View.Warning.playing)
            {
                View.Warning.Stop();
            }
        }
    }
}