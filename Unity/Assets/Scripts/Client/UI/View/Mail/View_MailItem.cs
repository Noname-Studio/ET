/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Mail
{
	public partial class View_MailItem : GButton
	{
		public Controller c1;
		public GButton YellowButton;
		public GButton BlueButton;

		public const string URL = "ui://ypdv1ldxg4h9cm";

		public static View_MailItem CreateInstance()
		{
			return (View_MailItem)UIPackage.CreateObject("Mail","MailItem");
		}

		public View_MailItem()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			c1 = this.GetControllerAt(0);
			YellowButton = (GButton)this.GetChildAt(2);
			BlueButton = (GButton)this.GetChildAt(3);
		}
	}
}