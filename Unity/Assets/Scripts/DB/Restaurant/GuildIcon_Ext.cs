namespace RestaurantPreview.Config
{
    public partial class GuildIconProperty
    {
        private static GuildIconProperty mDefaultFrame;
        public static GuildIconProperty DefaultFrame
        {
            get
            {
                return mDefaultFrame ?? (mDefaultFrame = Read(10001));
            }
        }

        private static GuildIconProperty mDefaultInside;
        public static GuildIconProperty DefaultInside
        {
            get
            {
                return mDefaultInside ?? (mDefaultInside = Read(20001));

            }
        }
    }
}