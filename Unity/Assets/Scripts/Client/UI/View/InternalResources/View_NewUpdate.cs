/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace InternalResources
{
    public partial class View_NewUpdate: GComponent
    {
        public GButton bg;
        public GLabel Content;
        public GButton UpdateButton;
        public GButton CancelButton;
        public const string URL = "ui://97pg0d8ft3u76";

        public static View_NewUpdate CreateInstance()
        {
            return (View_NewUpdate) UIPackage.CreateObject("InternalResources", "NewUpdate");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GButton) GetChild("bg");
            Content = (GLabel) GetChild("Content");
            UpdateButton = (GButton) GetChild("UpdateButton");
            CancelButton = (GButton) GetChild("CancelButton");
        }
    }
}