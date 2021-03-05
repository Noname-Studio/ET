/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_gift_team : GComponent
    {
        public View_yellow_light_circle light;
        public GTextField title;
        public GLoader plate;
        public GLoader loader;
        public const string URL = "ui://ucagdrsiocw9w08";

        public static View_gift_team CreateInstance()
        {
            return (View_gift_team)UIPackage.CreateObject("Common", "gift_team");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            light = (View_yellow_light_circle)GetChild("light");
            title = (GTextField)GetChild("title");
            plate = (GLoader)GetChild("plate");
            loader = (GLoader)GetChild("loader");
        }
    }
}