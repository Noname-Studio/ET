/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Quest
{
    public partial class View_ParticlesHolder: GComponent
    {
        public GGraph holder;

        public const string URL = "ui://ytnp4vk8nfmsmo";

        public static View_ParticlesHolder CreateInstance()
        {
            return (View_ParticlesHolder) UIPackage.CreateObject("Quest", "ParticlesHolder");
        }

        public View_ParticlesHolder()
        {
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            holder = (GGraph) GetChildAt(0);
        }
    }
}