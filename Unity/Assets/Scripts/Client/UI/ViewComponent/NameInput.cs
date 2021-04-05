using System.Text;
using FairyGUI;

namespace Client.UI.ViewComponent
{
    /// <summary>
    /// 用于防止用户在角色名称或者动物名称,公会名称等关键数据上使用非法字符
    /// </summary>
    public class NameInput
    {
        private GTextInput mInput { get; set; }
        private const int MaxLength = 16;

        public string Text => mInput.text;

        public NameInput(GTextInput input)
        {
            mInput = input;
            Init();
        }

        private void Init()
        {
            mInput.onChanged.Add(OnChanged);
        }

        private void OnChanged()
        {
            while (Encoding.UTF8.GetBytes(mInput.text).Length >= MaxLength)
            {
                mInput.text = mInput.text.Remove(mInput.text.Length - 1, 1);
            }
        }
    }
}