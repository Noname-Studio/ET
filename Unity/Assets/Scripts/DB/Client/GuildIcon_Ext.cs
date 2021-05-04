namespace RestaurantPreview.Config
{
    public partial class GuildIconProperty
    {
        private static GuildIconProperty mDefaultFrame;
        public static GuildIconProperty DefaultFrame => mDefaultFrame ??= Read(10001);

        private static GuildIconProperty mDefaultInside;
        public static GuildIconProperty DefaultInside => mDefaultInside ??= Read(20001);
    }
}