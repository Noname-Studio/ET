
namespace Kitchen
{
    public class KitchenRecord : NotifyObject
    {
        public KitchenRecord()
        {
        }

        private int mServicesOrderNumber;
        /// <summary>
        /// 服务食物数量
        /// </summary>
        public int ServicesOrderNumber {
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
        
        private int mLikeCount;
        /// <summary>
        /// 点赞数量
        /// </summary>
        public int LikeCount {
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
        
        private int mCoinNumber;
        /// <summary>
        /// 获得金币数量
        /// </summary>
        public int CoinNumber {
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
        
        private int mServicesCustomerNumber;
        /// <summary>
        /// 服务顾客数量
        /// </summary>
        public int ServicesCustomerNumber {
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
        
        private int mBurnFoodCount;
        /// <summary>
        /// 食物烧焦数量
        /// </summary>
        public int BurnFoodCount {
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
        
        private int mLostCustomerCount;
        /// <summary>
        /// 失去顾客数量
        /// </summary>
        public int LostCustomerCount {
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
        
        private int mDropFoodCount;
        /// <summary>
        /// 扔掉食物数量
        /// </summary>
        public int DropFoodCount {
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

        private float mPlayTime;
        /// <summary>
        /// 游玩时间
        /// </summary>
        public float PlayTime {
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
    }
}