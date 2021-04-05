/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace UI.Story.Mail
{
    public class MailBinder
    {
        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void BindAll()
        {
            UIObjectFactory.SetPackageItemExtension(View_MailContent.URL, typeof (View_MailContent));
            UIObjectFactory.SetPackageItemExtension(View_MailReward.URL, typeof (View_MailReward));
            UIObjectFactory.SetPackageItemExtension(View_Mail.URL, typeof (View_Mail));
            UIObjectFactory.SetPackageItemExtension(View_MailItem.URL, typeof (View_MailItem));
        }
    }
}