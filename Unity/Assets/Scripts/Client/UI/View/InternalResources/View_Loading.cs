/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace InternalResources
{
    public partial class View_Loading : GComponent
    {
        public View_LoadingProgress Progress;
        public GTextField Title;
        public GGraph FoodHolder;
        public GTextField Desc;
        public Transition t0;
        public const string URL = "ui://97pg0d8ft3u70";

        public static View_Loading CreateInstance()
        {
            return (View_Loading)UIPackage.CreateObject("InternalResources", "Loading");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            Progress = (View_LoadingProgress)GetChild("Progress");
            Title = (GTextField)GetChild("Title");
            FoodHolder = (GGraph)GetChild("FoodHolder");
            Desc = (GTextField)GetChild("Desc");
            t0 = GetTransition("t0");
        }
    }
}