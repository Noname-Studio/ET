/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Quest
{
	public partial class View_ProgressBar2 : GProgressBar
	{
		public View_ParticlesHolder Holder;

		public const string URL = "ui://ytnp4vk8ifeglx";

		public static View_ProgressBar2 CreateInstance()
		{
			return (View_ProgressBar2)UIPackage.CreateObject("Quest","ProgressBar2");
		}

		public View_ProgressBar2()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Holder = (View_ParticlesHolder)this.GetChildAt(2);
		}
	}
}