/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Shop
{
    public partial class View_DishesList : GComponent
    {
        public GList List;
        public const string URL = "ui://y7wvbjtcc8ss1";

        public static View_DishesList CreateInstance()
        {
            return (View_DishesList)UIPackage.CreateObject("Shop", "DishesList");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            List = (GList)GetChild("List");
        }
    }
}