using System.Diagnostics;
using FairyGUI;
using Panthea.Asset;

namespace Client.UI.ViewModel
{
    public partial class UI_EnterLevelPanel
    {
        //[Conditional("DEVELOPMENT_BUILD"), Conditional("UNITY_EDITOR")]
        private async void InitEditor()
        {
            /*var objects = await AssetsLocator.LoadAll(GameConfig.LevelConfigPath.TrimEnd('/') + AssetsConfig.Suffix);
            foreach(var node in objects)
            {
                var property = node.Value;
                if (!(property is LevelProperty))
                    continue;
                var button = (GButton) View.testSelRestList.AddItemFromPool();
                button.title = property.name;
                button.data = (LevelProperty)property;
                button.onClick.Add(SelectLevel);
            }*/
        }
        
        //[Conditional("DEVELOPMENT_BUILD"), Conditional("UNITY_EDITOR")]
        private void SelectLevel(EventContext context)
        {
            var button = (GButton)context.sender;
            var level = (LevelProperty) button.data;
            InitPanel(level);
        }
    }
}
