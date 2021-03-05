/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_TipForNpcGift : GComponent
    {
        public GButton bg;
        public GImage photo;
        public GList list;
        public GButton ok;
        public const string URL = "ui://ucagdrsiocw9w01";

        public static View_TipForNpcGift CreateInstance()
        {
            return (View_TipForNpcGift)UIPackage.CreateObject("Common", "TipForNpcGift");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton)GetChild("bg");
            photo = (GImage)GetChild("photo");
            list = (GList)GetChild("list");
            ok = (GButton)GetChild("ok");
        }
    }
}