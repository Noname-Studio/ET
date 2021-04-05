/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.CoinLevel
{
    public partial class View_coinchallenge: GComponent
    {
        public Controller c1;
        public Controller c2;
        public GTextField title;
        public GTextField title_en;

        public GButton Go;
        //public GLoader icon;

        public const string URL = "ui://yza5bcq0ldf1it";

        public static View_coinchallenge CreateInstance()
        {
            return (View_coinchallenge) UIPackage.CreateObject("CoinLevel", "coinchallenge");
        }

        public View_coinchallenge()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            c2 = GetControllerAt(1);
            title = (GTextField) GetChildAt(2);
            title_en = (GTextField) GetChildAt(3);
            Go = (GButton) GetChildAt(4);
            //icon = (GLoader)this.GetChildAt(8);
        }
    }
}