/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Fashion
{
    public partial class View_Mirror: GComponent
    {
        public View_CharacterMask Mask;

        public const string URL = "ui://e18f31pov62514";

        public static View_Mirror CreateInstance()
        {
            return (View_Mirror) UIPackage.CreateObject("Fashion", "Mirror");
        }

        public View_Mirror()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Mask = (View_CharacterMask) GetChildAt(3);
        }
    }
}