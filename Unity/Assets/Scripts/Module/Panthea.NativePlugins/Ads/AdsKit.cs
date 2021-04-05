namespace Panthea.NativePlugins.Ads
{
    public class AdsKit
    {
        public static IAdsHandler Inst { get; private set; }

        public static void Initialize(IAdsHandler handler)
        {
            Inst = handler;
        }
    }
}