using Client.Event;

namespace Kitchen
{
    public class KitchenRecord: NotifyObject
    {
        public KitchenRecord()
        { 
            MessageKit.Inst.Add<ComboLevelUp>(Event_ComboLevelUp);
            MessageKit.Inst.Add<MaxCombo>(Event_ComboLevelUp);
        }

        private void Event_ComboLevelUp(MaxCombo e)
        {
            Event_ComboLevelUp(e.Level);
        }

        private void Event_ComboLevelUp(ComboLevelUp e)
        {
            Event_ComboLevelUp(e.Level);
        }

        private void Event_ComboLevelUp(int level)
        {
            if (level <= 2)
                return;
            else if (level == 3)
                Combo3++;
            else if (level == 4)
                Combo4++;
            //这里播放特效
            CoinNumber += level * 10;
        }

        public void Dispose()
        {
            MessageKit.Inst.Remove<ComboLevelUp>(Event_ComboLevelUp);
            MessageKit.Inst.Remove<MaxCombo>(Event_ComboLevelUp);
        }

        private int mServicesOrderNumber;
        private int mLikeCount;
        private int mCoinNumber;
        private int mServicesCustomerNumber;
        private int mBurnFoodCount;
        private int mLostCustomerCount;
        private int mDropFoodCount;
        private float mPlayTime;
        private int mTipsNumber;
        public int Combo3 { get; private set; }
        public int Combo4 { get; private set; }
        /// <summary>
        /// 服务食物数量
        /// </summary>
        public int ServicesOrderNumber
        {
            get => mServicesOrderNumber;
            set
            {
                //服务食物数量不能下降.只能上升
                if (mServicesOrderNumber < value)
                {
                    var oldValue = mServicesOrderNumber;
                    mServicesOrderNumber = value;
                    NotifyPropertyChanged(oldValue, value);
                }
            }
        }

        /// <summary>
        /// 点赞数量
        /// </summary>
        public int LikeCount
        {
            get => mLikeCount;
            set
            {
                //点赞数量不能下降.只能上升
                if (mLikeCount < value)
                {
                    var oldValue = mLikeCount;
                    mLikeCount = value;
                    NotifyPropertyChanged(oldValue, value);
                }
            }
        }

        /// <summary>
        /// 获得金币数量
        /// </summary>
        public int CoinNumber
        {
            get => mCoinNumber;
            set
            {
                //钱是不可能退的.这辈子都不可能退的.进了我的钱包就是我得了
                if (mCoinNumber < value)
                {
                    var oldValue = mCoinNumber;
                    mCoinNumber = value;
                    NotifyPropertyChanged(oldValue, value);
                }
            }
        }

        public int TipsNumber
        {
            get => mTipsNumber;
            set
            {
                //钱是不可能退的.这辈子都不可能退的.进了我的钱包就是我得了
                if (mTipsNumber < value)
                {
                    var oldValue = mTipsNumber;
                    mTipsNumber = value;
                    NotifyPropertyChanged(oldValue, value);
                }
            }
        }

        /// <summary>
        /// 服务顾客数量
        /// </summary>
        public int ServicesCustomerNumber
        {
            get => mServicesCustomerNumber;
            set
            {
                //服务顾客数量是不会下降得
                if (mServicesCustomerNumber < value)
                {
                    var oldValue = mServicesCustomerNumber;
                    mServicesCustomerNumber = value;
                    NotifyPropertyChanged(oldValue, value);
                }
            }
        }

        /// <summary>
        /// 食物烧焦数量
        /// </summary>
        public int BurnFoodCount
        {
            get => mBurnFoodCount;
            set
            {
                //食物烧焦数量是不会下降得
                if (mBurnFoodCount < value)
                {
                    var oldValue = mBurnFoodCount;
                    mBurnFoodCount = value;
                    NotifyPropertyChanged(oldValue, value);
                }
            }
        }

        /// <summary>
        /// 失去顾客数量
        /// </summary>
        public int LostCustomerCount
        {
            get => mLostCustomerCount;
            set
            {
                //失去顾客数量是不会下降得
                if (mLostCustomerCount < value)
                {
                    var oldValue = mLostCustomerCount;
                    mLostCustomerCount = value;
                    NotifyPropertyChanged(oldValue, value);
                }
            }
        }

        /// <summary>
        /// 扔掉食物数量
        /// </summary>
        public int DropFoodCount
        {
            get => mDropFoodCount;
            set
            {
                //扔掉食物数量是不会下降得
                if (mDropFoodCount < value)
                {
                    var oldValue = mDropFoodCount;
                    mDropFoodCount = value;
                    NotifyPropertyChanged(oldValue, value);
                }
            }
        }

        /// <summary>
        /// 游玩时间
        /// </summary>
        public float PlayTime
        {
            get => mPlayTime;
            set
            {
                //游玩时间是不会下降得
                if (mPlayTime < value)
                {
                    var oldValue = mPlayTime;
                    mPlayTime = value;
                    NotifyPropertyChanged(oldValue, value);
                }
            }
        }

        public void Reset()
        {
            mServicesOrderNumber = 0;
            mLikeCount = 0;
            mCoinNumber = 0;
            mServicesCustomerNumber = 0;
            mBurnFoodCount = 0;
            mLostCustomerCount = 0;
            mDropFoodCount = 0;
            mPlayTime = 0;
            mTipsNumber = 0;
        }
    }
}