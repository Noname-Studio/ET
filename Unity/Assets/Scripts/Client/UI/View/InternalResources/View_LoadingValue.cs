/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace InternalResources
{
    public partial class View_LoadingValue: GComponent
    {
        public GImage bar;
        public const string URL = "ui://97pg0d8ft3u73";

        public static View_LoadingValue CreateInstance()
        {
            return (View_LoadingValue) UIPackage.CreateObject("InternalResources", "LoadingValue");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bar = (GImage) GetChild("bar");
        }
    }
}