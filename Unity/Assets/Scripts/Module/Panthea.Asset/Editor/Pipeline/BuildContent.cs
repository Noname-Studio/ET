using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;

namespace Panthea.Editor.Asset
{
    public class BuildContent: AResPipeline
    {
        protected AddressableAssetSettings AddressableBuilder;

        public BuildContent(AddressableAssetSettings settings)
        {
            AddressableBuilder = settings;
        }

        public override Task Do()
        {
            bool hasBuilderMode = false;
            for (var index = 0; index < AddressableBuilder.DataBuilders.Count; index++)
            {
                var node = AddressableBuilder.DataBuilders[index];
                if (node is XAssetBundleBuildMode)
                {
                    AddressableBuilder.ActivePlayerDataBuilderIndex = index;
                    hasBuilderMode = true;
                    break;
                }
            }

            if (!hasBuilderMode)
            {
                XAssetBundleBuildMode asset = ScriptableObject.CreateInstance<XAssetBundleBuildMode>();
                AssetDatabase.CreateAsset(asset, "Assets/AddressableAssetsData/DataBuilders/XFrameworkBuild.asset");
                AssetDatabase.SaveAssets();
                AddressableBuilder.AddDataBuilder(asset, false);
                AddressableBuilder.SetDataBuilderAtIndex(0, asset, false);
                AddressableBuilder.ActivePlayerDataBuilderIndex = 0;
            }

            AddressableAssetSettings.BuildPlayerContent();
            return Task.CompletedTask;
        }
    }
}