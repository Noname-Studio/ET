using System.Collections.Generic;
using FairyGUI;

namespace Client.UI.ViewComponent
{
    public class Combo_SelectLanguage
    {
        public GComboBox Component { get; }

        public string Value
        {
            get
            {
                return Component.value;
            }
            set
            {
                this.Component.value = value;
            }
        }
        
        private static string[] CacheItems;
        public Combo_SelectLanguage(GComboBox comboBox)
        {
            this.Component = comboBox;
            this.Init();
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
            this.Component.items = CacheItems;
            this.Component.values = CacheItems;
        }
    }
}