/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_Block : GComponent
    {
        public GTextField text;
        public GGraph Background;
        public const string URL = "ui://ucagdrsiqme3vv3";

        public static View_Block CreateInstance()
        {
            return (View_Block)UIPackage.CreateObject("Common", "Block");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            text = (GTextField)GetChild("text");
            Background = (GGraph)GetChild("Background");
        }
    }
}