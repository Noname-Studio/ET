/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.QuizGame
{
	public partial class View_QuizGame : GComponent
	{
		public Controller c1;
		public GButton bg;
		public View_Label1 frame;
		public GButton Close;
		public GButton more;
		public GButton tryAgain;
		public GButton share;
		public View_play start;
		public View_tips playTip;
		public View_tips_star moreTip;
		public View_tips_share group1;
		public View_freestar helperBar;
		public View_sharing shareTip;

		public const string URL = "ui://btrw885im8faeb";

		public static View_QuizGame CreateInstance()
		{
			return (View_QuizGame)UIPackage.CreateObject("QuizGame","QuizGame");
		}

		public View_QuizGame()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = this.GetControllerAt(0);
			bg = (GButton)this.GetChildAt(0);
			frame = (View_Label1)this.GetChildAt(4);
			Close = (GButton)this.GetChildAt(7);
			more = (GButton)this.GetChildAt(8);
			tryAgain = (GButton)this.GetChildAt(9);
			share = (GButton)this.GetChildAt(10);
			start = (View_play)this.GetChildAt(11);
			playTip = (View_tips)this.GetChildAt(12);
			moreTip = (View_tips_star)this.GetChildAt(13);
			group1 = (View_tips_share)this.GetChildAt(14);
			helperBar = (View_freestar)this.GetChildAt(15);
			shareTip = (View_sharing)this.GetChildAt(18);
		}
	}
}