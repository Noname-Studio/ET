/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_cw_updata_item : GComponent
    {
        public Controller state;
        public GLoader icon0;
        public GTextField val;
        public GImage arrow;
        public GLoader icon1;
        public GTextField newval;
        public GLoader icon;
        public GTextField maxal;
        public GTextField name;
        public const string URL = "ui://ucagdrsi7pufvvm";

        public static View_cw_updata_item CreateInstance()
        {
            return (View_cw_updata_item)UIPackage.CreateObject("Common", "cw_updata_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            state = GetController("state");
            icon0 = (GLoader)GetChild("icon0");
            val = (GTextField)GetChild("val");
            arrow = (GImage)GetChild("arrow");
            icon1 = (GLoader)GetChild("icon1");
            newval = (GTextField)GetChild("newval");
            icon = (GLoader)GetChild("icon");
            maxal = (GTextField)GetChild("maxal");
            name = (GTextField)GetChild("name");
        }
    }
}