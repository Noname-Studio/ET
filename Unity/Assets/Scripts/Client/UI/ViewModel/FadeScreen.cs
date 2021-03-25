using Cysharp.Threading.Tasks;
using Effect;
using FairyGUI;

/// <summary>
/// 屏幕一黑一亮的渐变过度效果
/// </summary>
public class FadeScreen : IEffect
{
    private View_FadeScreen mFadeScreen;
    public void Do()
    {
    }

    public bool IsPlaying => mFadeScreen.t0.playing;

    public FadeScreen()
    {
        mFadeScreen = View_FadeScreen.CreateInstance();
        GRoot.inst.AddChild(mFadeScreen);
        mFadeScreen.sortingOrder = int.MaxValue;
    }

    public async UniTask PlayDark()
    {
        mFadeScreen.t0.PlayReverse();
        while (IsPlaying)
        {
            await UniTask.NextFrame();
        }
    }

    public async UniTask PlayWhite()
    {
        mFadeScreen.t0.Play();
        while (IsPlaying)
        {
            await UniTask.NextFrame();
        }
    }

    public void Dispose()
    {
        mFadeScreen.Dispose();
    }
}
