using Client.UI.ViewModel;
using FairyGUI;
using Spine.Unity;
using UnityEngine;

namespace Kitchen
{
    public class CookwareRenderer
    {
        private readonly NormalCookware mDisplay;
        private readonly CookwareProperty mProperty;
        private readonly CookwareDetailProperty mCookwareDetail;
        private readonly UI_CookwareProgress mCookwareProgress;
        private UI_CookFood mCookResult;
        private float mWorkTime;
        private float mBurnTime;
        private CookwareState mState;

        public CookwareRenderer(NormalCookware display)
        {
            mDisplay = display;
            mProperty = mDisplay.Property;
            mCookwareDetail = mDisplay.CookwareDetail;
            mCookwareProgress = UIKit.Inst.Create<UI_CookwareProgress>();
            Vector3 screenPos = KitchenRoot.Inst.MainCamera.WorldToScreenPoint(display.Animation.ClockPos);
            screenPos.y = Screen.height - screenPos.y;
            var pt = GRoot.inst.GlobalToLocal(screenPos);
            mCookwareProgress.View.position = pt;
            CreateFood();
        }

        /// <summary>
        /// 创建显示盘子
        /// </summary>
        private void CreateFood()
        {
            mCookResult = UIKit.Inst.Create<UI_CookFood>();
            mCookResult.View.visible = false;
            Vector3 screenPos = KitchenRoot.Inst.MainCamera.WorldToScreenPoint(mDisplay.Animation.FoodPos);
            screenPos.y = Screen.height - screenPos.y;
            var pt = GRoot.inst.GlobalToLocal(screenPos);
            mCookResult.View.position = pt;
        }

        public void RefreshCount()
        {
            if (mDisplay.FoodCount <= 1)
            {
                mCookResult.View.Number.text = "";
            }
            else
            {
                mCookResult.View.Number.text = "x" + mDisplay.FoodCount;
            }
        }

        /// <summary>
        /// 更新显示状态
        /// </summary>
        /// <param name="state"></param>
        public void ChangeState(CookwareState state)
        {
            mState = state;
            if (state == CookwareState.Burned || state == CookwareState.Done)
            {
                SetDisplayFoodId(mDisplay.FoodId);
            }
            else if (state == CookwareState.Idle || state == CookwareState.Work || state == CookwareState.Broken)
            {
                SetDisplayFoodId(null);
            }

            mCookwareProgress.SetState(state);
        }

        /// <summary>
        /// 设置显示食物ID
        /// </summary>
        /// <param name="id"></param>
        private void SetDisplayFoodId(string id)
        {
            if (id == null)
            {
                Reset();
                return;
            }

            var property = KitchenDataHelper.LoadFood(id);
            mCookResult.View.Plate.url = "Image/Food/plate1_1";
            mCookResult.View.Food.url = property.Texture;
            mCookResult.View.visible = true;
            RefreshCount();
        }

        private void Reset()
        {
            mCookResult.View.visible = false;
            mWorkTime = 0;
            mBurnTime = 0;
        }

        public void Update()
        {
            if (mState == CookwareState.Work)
            {
                mWorkTime += Time.unscaledDeltaTime;
                mCookwareProgress.SetFill(mWorkTime / mCookwareDetail.WorkTime);
                if (mWorkTime >= mCookwareDetail.WorkTime)
                {
                    mDisplay.FinishWork();
                }
            }
            else if (mState == CookwareState.Burning)
            {
                if (mCookwareDetail.BurnTime != 0)
                {
                    mBurnTime += Time.unscaledDeltaTime;
                    mCookwareProgress.SetFill(mBurnTime / mCookwareDetail.BurnTime);
                    if (mBurnTime >= mCookwareDetail.BurnTime)
                    {
                        mDisplay.BurntFood();
                    }
                }
            }
            else
            {
                mWorkTime = 0;
                mBurnTime = 0;
            }
        }
    }
}