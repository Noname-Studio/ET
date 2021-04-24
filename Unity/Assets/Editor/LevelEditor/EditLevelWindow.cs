using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Sirenix.OdinInspector.Demos.RPGEditor;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEditor.Graphs.AnimationBlendTree;
using UnityEngine;

public class EditLevelWindow: OdinMenuEditorWindow
{
    [MenuItem("Tools/Restaurant/Kitchen/刷新所有Property的资源路径")]
    private static void Test()
    {
        foreach (var node in Directory.GetFiles("Assets/Res/" + GameConfig.CustomerConfigPath, "*.asset", SearchOption.AllDirectories))
        {
            var path = PathUtils.FullPathToUnityPath(node);
            var customerProperty = AssetDatabase.LoadAssetAtPath<CustomerProperty>(path);
            customerProperty.UpdatePath();
            EditorUtility.SetDirty(customerProperty);
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    [MenuItem("Tools/Restaurant/Kitchen/Open Edit Level Window")]
    private static void Open()
    {
        var window = GetWindow<EditLevelWindow>();
        window.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 500);
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree(false);
        tree.DefaultMenuStyle.IconSize = 28.00f;
        tree.Config.DrawSearchToolbar = true;
        tree.Add("关卡全局配置", AssetDatabase.LoadAssetAtPath<KitchenConfigProperty>("Assets/Res/Config/Kitchen/KitchenConfig.asset"));
        Dictionary<string, int> dupFilter = new Dictionary<string, int>();

        foreach (var node in RestaurantKey.All)
        {
            tree.Add("关卡/" + node.Key,
                AssetDatabase.LoadAssetAtPath<EditorLevelGenerator>($"Assets/Editor/LevelEditor/{node.Key}LevelGeneratorAssets.asset"));
        }

        foreach (string node in Directory.GetFiles(Application.dataPath + "/Res/Config/Kitchen/Levels/", "*.asset", SearchOption.TopDirectoryOnly))
        {
            var property = AssetDatabase.LoadAssetAtPath<LevelProperty>(PathUtils.FullPathToUnityPath(node));
            if (property == null)
            {
                continue;
            }

            string rest = property.RestaurantId.Key;
            if (rest == RestaurantKey.Unknown.Key)
            {
                tree.Add("关卡/" + rest + "/" + property.name, property);
            }
            else
            {
                int counter = 0;
                string menu = "关卡/" + rest + "/" + property.LevelId;
                if (!dupFilter.TryGetValue(menu, out counter))
                {
                    tree.Add(menu, property);
                    dupFilter[menu] = 0;
                }
                else
                {
                    tree.Add(menu + "(" + counter + ")", property);
                    dupFilter[menu]++;
                }
            }
        }

        tree.AddAllAssetsAtPath("食物", "Assets/Res/Config/Kitchen/Foods/", typeof (FoodProperty), true, true).AddIcons(t1 =>
        {
            var value = t1.Value as FoodProperty;
            if (value != null)
            {
                return typeof (FoodProperty).GetField("mEditorTexture", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(value) as Texture;
                //return value.EditorTexture;
            }

            return null;
        }).SortMenuItemsByName();

        /*tree.AddAllAssetsAtPath("食材", "Assets/Res/Config/Kitchen/Ingredient/", typeof (IngredientProperty), true, true).AddIcons(t1 =>
        {
            var value = t1.Value as IngredientProperty;
            if (value != null)
            {
                return typeof (IngredientProperty).GetField("mEditorTexture", BindingFlags.Instance | BindingFlags.NonPublic)
                        .GetValue(value) as Texture;
            }

            return null;
        });*/

        dupFilter.Clear();
        foreach (string node in Directory.GetFiles(Application.dataPath + "/Res/Config/Kitchen/Cookwares/", "*", SearchOption.TopDirectoryOnly))
        {
            var property = AssetDatabase.LoadAssetAtPath<CookwareProperty>(PathUtils.FullPathToUnityPath(node));
            if (property == null)
            {
                continue;
            }

            string rest = property.RestaurantId.Key;
            var icon =
                    typeof (CookwareProperty).GetField("mEditorTexture", BindingFlags.Instance | BindingFlags.NonPublic)
                            .GetValue(property) as Texture;
            if (rest == RestaurantKey.Unknown.Key)
            {
                tree.Add("厨具/" + rest + "/" + property.name, property, icon);
            }
            else
            {
                int counter = 0;
                string menu = "厨具/" + rest + "/" + property.Key;
                if (!dupFilter.TryGetValue(menu, out counter))
                {
                    tree.Add(menu, property, icon);
                    dupFilter[menu] = 0;
                }
                else
                {
                    tree.Add(menu + "(" + counter + ")", property, icon);
                    dupFilter[menu]++;
                }
            }
        }

        tree.AddAllAssetsAtPath("顾客", "Assets/Res/Config/Kitchen/Customer/", typeof (CustomerProperty), true, true).AddIcons(t1 =>
        {
            var value = t1.Value as CustomerProperty;
            if (value != null)
            {
                return typeof (CustomerProperty).GetField("mEditorTexture", BindingFlags.Instance | BindingFlags.NonPublic)
                        .GetValue(value) as Texture;
            }

            return null;
        });

        tree.EnumerateTree().Where(x => x.Value as ScriptableObject).ForEach(AddDragHandles);
        //tree.SortMenuItemsByName();

        /*// Adds all characters.

        // Add all scriptable object items.
        tree.AddAllAssetsAtPath("", "Assets/Plugins/Sirenix/Demos/SAMPLE - RPG Editor/Items", typeof(Item), true)
            .ForEach(this.AddDragHandles);

        // Add drag handles to items, so they can be easily dragged into the inventory if characters etc...

        // Add icons to characters and items.
        tree.EnumerateTree().AddIcons<Character>(x => x.Icon);
        */
        return tree;
    }

    private void AddDragHandles(OdinMenuItem menuItem)
    {
        menuItem.OnDrawItem += x => x.OnRightClick += item =>
        {
            EditorGUIUtility.PingObject((Object) item.Value);
            Selection.objects = new[] { (Object) item.Value };
        };
    }

    protected override void OnBeginDrawEditors()
    {
        var selected = MenuTree.Selection.FirstOrDefault();
        var toolbarHeight = MenuTree.Config.SearchToolbarHeight;

        // Draws a toolbar with the name of the currently selected menu item.
        SirenixEditorGUI.BeginHorizontalToolbar(toolbarHeight);
        {
            if (selected != null)
            {
                GUILayout.Label(selected.Name);
            }

            if (SirenixEditorGUI.ToolbarButton(new GUIContent("创建关卡")))
            {
                ScriptableObjectCreator.ShowDialog<LevelProperty>("Assets/Res/Config/Kitchen/Levels", obj =>
                {
                    TrySelectMenuItemWithObject(obj); // Selects the newly created item in the editor
                });
            }

            if (SirenixEditorGUI.ToolbarButton(new GUIContent("创建食物")))
            {
                ScriptableObjectCreator.ShowDialog<FoodProperty>("Assets/Res/Config/Kitchen/Foods", obj =>
                {
                    TrySelectMenuItemWithObject(obj); // Selects the newly created item in the editor
                });
            }

            /*if (SirenixEditorGUI.ToolbarButton(new GUIContent("创建食材")))
            {
                ScriptableObjectCreator.ShowDialog<IngredientProperty>("Assets/Res/Config/Kitchen/Ingredient", obj =>
                {
                    TrySelectMenuItemWithObject(obj); // Selects the newly created item in the editor
                });
            }*/

            if (SirenixEditorGUI.ToolbarButton(new GUIContent("创建厨具")))
            {
                ScriptableObjectCreator.ShowDialog<CookwareProperty>("Assets/Res/Config/Kitchen/Cookwares", obj =>
                {
                    TrySelectMenuItemWithObject(obj); // Selects the newly created item in the editor
                });
            }

            if (SirenixEditorGUI.ToolbarButton(new GUIContent("创建顾客")))
            {
                ScriptableObjectCreator.ShowDialog<CustomerProperty>("Assets/Res/Config/Kitchen/Customer", obj =>
                {
                    TrySelectMenuItemWithObject(obj); // Selects the newly created item in the editor
                });
            }
        }
        SirenixEditorGUI.EndHorizontalToolbar();
    }
}