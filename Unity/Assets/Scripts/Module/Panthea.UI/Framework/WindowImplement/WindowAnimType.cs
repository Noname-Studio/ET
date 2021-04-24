//这里使用Enum会更加简单.但是Enum再tostring得过程中会产生大量得性能消耗和GC.

using System;

public enum WindowAnimType
{
    None,
    FadeIn, //淡入
    FadeOut, //淡出
    ScaleToZero, //缩放至0
    ScaleToNormal, //缩放至原始大小
    Fall, //从上往下(显示：从屏幕上端移动到屏幕中间，隐藏：从屏幕中间移动到屏幕下端)
    Rise, //从下往上(显示：从屏幕下端移动到屏幕中间，隐藏：从屏幕中间移动到屏幕上端)
    Custom //自定义动画,标记为这个类型的动画.可以重写DoHideAnimation/DoShowAnimation来做自定义的动画
}

public static class WindowAnimTypeExt
{
    public static string ToName(this WindowAnimType type)
    {
        switch (type)
        {
            case WindowAnimType.None:
                return nameof (WindowAnimType.None);
            case WindowAnimType.FadeIn:
                return nameof (WindowAnimType.FadeIn);
            case WindowAnimType.FadeOut:
                return nameof (WindowAnimType.FadeOut);
            case WindowAnimType.ScaleToZero:
                return nameof (WindowAnimType.ScaleToZero);
            case WindowAnimType.ScaleToNormal:
                return nameof (WindowAnimType.ScaleToNormal);
            case WindowAnimType.Fall:
                return nameof (WindowAnimType.Fall);
            case WindowAnimType.Rise:
                return nameof (WindowAnimType.Rise);
            case WindowAnimType.Custom:
                return nameof (WindowAnimType.Custom);
            default:
                throw new ArgumentOutOfRangeException(nameof (type), type, null);
        }
    }
}