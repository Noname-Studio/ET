using System.Collections.Generic;
using FairyGUI;
using RestaurantPreview.Config;

namespace Client.UI.ViewComponent
{
    public class Combo_SelectRestaurant
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
        private static string[] CacheValues;
        public Combo_SelectRestaurant(GComboBox comboBox)
        {
            this.Component = comboBox;
            this.Init();
        }

        static Combo_SelectRestaurant()
        {
            var values = new List<string>();
            var items = new List<string>();
            foreach (var node in RestaurantKey.All)
            {
                values.Add(node.Key);
                items.Add(LocalizationProperty.Read(node.Key));
            }
            CacheItems = items.ToArray();
            CacheValues = values.ToArray();
        }

        private void Init()
        {
            this.Component.items = CacheItems;
            this.Component.values = CacheValues;
        }
    }
}