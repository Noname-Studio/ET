/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Common
{
    public partial class View_xiaoludian : GComponent
    {
        public GImage tanhao;
        public Transition t0;
        public Transition t1;
        public const string URL = "ui://ucagdrsi9sowpl";

        public static View_xiaoludian CreateInstance()
        {
            return (View_xiaoludian)UIPackage.CreateObject("Common", "xiaoludian");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tanhao = (GImage)GetChild("tanhao");
            t0 = GetTransition("t0");
            t1 = GetTransition("t1");
        }
    }
}