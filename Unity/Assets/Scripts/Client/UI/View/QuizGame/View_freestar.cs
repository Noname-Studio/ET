/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.QuizGame
{
	public partial class View_freestar : GComponent
	{
		public GComponent light;
		public GImage Image1;
		public GTextField Text;
		public GImage Image;
		public GGroup effectGroup;
		public Transition t0;

		public const string URL = "ui://btrw885inpzihi";

		public static View_freestar CreateInstance()
		{
			return (View_freestar)UIPackage.CreateObject("QuizGame","freestar");
		}

		public View_freestar()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			light = (GComponent)this.GetChildAt(2);
			Image1 = (GImage)this.GetChildAt(3);
			Text = (GTextField)this.GetChildAt(4);
			Image = (GImage)this.GetChildAt(8);
			effectGroup = (GGroup)this.GetChildAt(10);
			t0 = this.GetTransitionAt(0);
		}
	}
}