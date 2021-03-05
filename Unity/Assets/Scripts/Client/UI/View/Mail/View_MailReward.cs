/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Mail
{
	public partial class View_MailReward : GLabel
	{
		public GTextField itemName;

		public const string URL = "ui://ypdv1ldxg4h9ch";

		public static View_MailReward CreateInstance()
		{
			return (View_MailReward)UIPackage.CreateObject("Mail","MailReward");
		}

		public View_MailReward()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			itemName = (GTextField)this.GetChildAt(3);
		}
	}
}