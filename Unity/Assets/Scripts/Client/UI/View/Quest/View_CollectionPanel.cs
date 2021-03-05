/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Story.Quest
{
	public partial class View_CollectionPanel : GComponent
	{
		public GList List;
		public GList Collection;
		public GTextField MiscDesc;

		public const string URL = "ui://ytnp4vk8b0bmnh";

		public static View_CollectionPanel CreateInstance()
		{
			return (View_CollectionPanel)UIPackage.CreateObject("Quest","CollectionPanel");
		}

		public View_CollectionPanel()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			List = (GList)this.GetChildAt(4);
			Collection = (GList)this.GetChildAt(5);
			MiscDesc = (GTextField)this.GetChildAt(6);
		}
	}
}