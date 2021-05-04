using Client.Event;

namespace Kitchen
{
    public class KitchenRecord: NotifyObject
    {
        private int mServicesOrderNumber;
        private int mLikeCount;
        private int mCoinNumber;
        private int mServicesCustomerNumber;
        private int mBurnFoodCount;
        private int mLostCustomerCount;
        private int mDropFoodCount;
        private float mPlayTime;
        private int mTipsNumber;
        private int mCombo3;
        private int mCombo4;

        /// <summary>
        /// 3连击次数
        /// </summary>
        public int Combo3
        {
            get => mCombo3;
            set
            {
                //连击达成次数不能下降.只能上升
                if (mCombo3 < value)
                {
                    var oldValue = mCombo3;
                    mCombo3 = value;
                    NotifyPropertyChanged(oldValue, value);
                }
            }
        }

        /// <summary>
        /// 4连击次数
        /// </summary>
        public int Combo4
        {
            get => mCombo4;
            set
            {
                //连击达成次数不能下降.只能上升
                if (mCombo4 < value)
                {
                    var oldValue = mCombo4;
                    mCombo4 = value;
                    NotifyPropertyChanged(oldValue, value);
                }
            }
        }

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