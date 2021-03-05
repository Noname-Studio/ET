using Effect;
using FairyGUI;

/// <summary>
/// 屏幕一黑一亮的渐变过度效果
/// </summary>
public class FadeScreen : IEffect
{
    private View_FadeScreen mFadeScreen;
    public bool IsPlaying => mFadeScreen.t0.playing;

    public void Do()
    {
        mFadeScreen = View_FadeScreen.CreateInstance();
        GRoot.inst.AddChild(mFadeScreen);
        mFadeScreen.sortingOrder = int.MaxValue;
    }

    public void PlayDark()
    {
        mFadeScreen.t0.PlayReverse();
    }

    public void PlayWhite()
    {
        mFadeScreen.t0.Play();
    }

    public void Dispose()
    {
        mFadeScreen.Dispose();
    }
}
