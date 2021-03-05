/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Mail
{
	public partial class View_MailContent : GComponent
	{
		public GButton bg;
		public GButton Close;
		public GButton Get;
		public GRichTextField Content;
		public GList GiftList;

		public const string URL = "ui://ypdv1ldxg4h9cc";

		public static View_MailContent CreateInstance()
		{
			return (View_MailContent)UIPackage.CreateObject("Mail","MailContent");
		}

		public View_MailContent()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			bg = (GButton)this.GetChildAt(0);
			Close = (GButton)this.GetChildAt(3);
			Get = (GButton)this.GetChildAt(4);
			Content = (GRichTextField)this.GetChildAt(5);
			GiftList = (GList)this.GetChildAt(6);
		}
	}
}