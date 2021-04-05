/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Fashion
{
    public partial class View_CharacterMask: GComponent
    {
        public GGraph ModelPlace;

        public const string URL = "ui://e18f31pov62515";

        public static View_CharacterMask CreateInstance()
        {
            return (View_CharacterMask) UIPackage.CreateObject("Fashion", "CharacterMask");
        }

        public View_CharacterMask()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            ModelPlace = (GGraph) GetChildAt(0);
        }
    }
}