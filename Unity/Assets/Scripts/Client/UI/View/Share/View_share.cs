/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Share
{
    public partial class View_share: GComponent
    {
        public View_WenAnKa Card;
        public GButton Confrim;
        public GButton Cancel;
        public View_XiangPian Picture;
        public Transition appear;
        public Transition share;
        public Transition share_later;

        public const string URL = "ui://ypf7zkklmom6ks";

        public static View_share CreateInstance()
        {
            return (View_share) UIPackage.CreateObject("Share", "share");
        }

        public View_share()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Card = (View_WenAnKa) GetChildAt(4);
            Confrim = (GButton) GetChildAt(5);
            Cancel = (GButton) GetChildAt(6);
            Picture = (View_XiangPian) GetChildAt(7);
            appear = GetTransitionAt(0);
            share = GetTransitionAt(1);
            share_later = GetTransitionAt(2);
        }
    }
}