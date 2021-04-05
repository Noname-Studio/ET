using System.Collections.Generic;
using FairyGUI;

namespace Client.UI.ViewComponent
{
    public class Combo_SelectLanguage
    {
        public GComboBox Component { get; }

        public string Value
        {
            get => Component.value;
            set => Component.value = value;
        }

        private static string[] CacheItems;

        public Combo_SelectLanguage(GComboBox comboBox)
        {
            Component = comboBox;
            Init();
        }

        static Combo_SelectLanguage()
        {
            var list = new List<string>();
            foreach (var node in Language.All)
            {
                list.Add(node.Name);
            }

            CacheItems = list.ToArray();
        }

        private void Init()
        {
            Component.items = CacheItems;
            Component.values = CacheItems;
        }
    }
}