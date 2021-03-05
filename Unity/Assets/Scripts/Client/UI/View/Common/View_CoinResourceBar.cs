/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_CoinResourceBar : GLabel
    {
        public GLoader Image;
        public GTextField Text;
        public const string URL = "ui://ucagdrsit4lrvxz";

        public static View_CoinResourceBar CreateInstance()
        {
            return (View_CoinResourceBar)UIPackage.CreateObject("Common", "CoinResourceBar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Image = (GLoader)GetChild("Image");
            Text = (GTextField)GetChild("Text");
        }
    }
}