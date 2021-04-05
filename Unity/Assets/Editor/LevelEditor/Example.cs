using System;
using System.IO;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
[InlineProperty]
[InlineEditor(Expanded = true)]
public class Example: ScriptableObject
{
    [LabelText("123123")]
    public Texture2D PreviewIcon;
}

[CustomEditor(typeof (Example))]
public class ExampleEditor: OdinEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }

    public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
    {
        Example example = (Example) target;

        if (example == null || example.PreviewIcon == null)
        {
            return null;
        }

        Texture2D tex = new Texture2D(width, height, example.PreviewIcon.format, false);
        EditorUtility.CopySerialized(example.PreviewIcon, tex);

        return tex;
    }
}