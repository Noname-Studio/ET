namespace Panthea.NativePlugins.Ads
{
    public class AdsFlag
    {
        private string Value { get; }
        public AdsFlag(string str)
        {
            Value = str;
        }

        public static AdsFlag RewardVideoPlacementId = new AdsFlag("rewardedVideo");
        public static AdsFlag VideoPlacementId = new AdsFlag("video");

        public override string ToString()
        {
            return Value;
        }
    }
}