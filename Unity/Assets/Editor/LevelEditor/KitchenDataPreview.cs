using System;
using System.Reflection;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class MyPreview: OdinEditor
{
    public virtual Type Type { get; }

    public override bool HasPreviewGUI()
    {
        return true;
    }

    public override bool RequiresConstantRepaint()
    {
        return true;
    }

    public override void OnPreviewGUI(Rect r, GUIStyle background)
    {
        try
        {
            if (Event.current.type != EventType.Repaint)
            {
                return;
            }

            var texture = Type.GetField("mEditorTexture", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(target) as Texture2D;
            GUI.DrawTexture(r, texture, ScaleMode.ScaleToFit, true);
        }
        catch (Exception e)
        {
            Debug.LogError(Type.Name + "Error\n" + e);
        }
    }

    public Texture2D DeCompress(Texture2D source)
    {
        RenderTexture renderTex = RenderTexture.GetTemporary(source.width,
            source.height,
            0,
            RenderTextureFormat.Default,
            RenderTextureReadWrite.Linear);

        Graphics.Blit(source, renderTex);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = renderTex;
        Texture2D readableText = new Texture2D(source.width, source.height);
        readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
        readableText.Apply();
        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(renderTex);
        return readableText;
    }

    public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
    {
        try
        {
            var texture = Type.GetField("mEditorTexture", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(target) as Texture2D;
            if (texture == null)
            {
                return null;
            }

            //var texture = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Res/Image/Food/Breakfast/tex_asparagus_omelette.png");
            /*Debug.LogError(texture);
            Texture2D tex = new Texture2D(width, height, texture.format, false);
            EditorUtility.CopySerialized(texture, tex);*/
            var tex = DeCompress(texture);
            return tex;
        }
        catch (Exception e)
        {
            Debug.LogError(Type + "   \n" + e);
            return null;
        }
    }

    /*public override void OnInteractivePreviewGUI(Rect r, GUIStyle background)
    {
        try
        {
            if (Event.current.type != UnityEngine.EventType.Repaint)
                return;
            var texture = Type.GetField("mEditorTexture", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(target) as Texture2D;
            GUI.DrawTexture(r, texture, ScaleMode.ScaleToFit, true);
        }
        catch(Exception e )
        {
            Debug.LogError(Type.Name + "Error\n" + e);
        }

    }*/
}

[CustomEditor(typeof (FoodProperty))]
[CanEditMultipleObjects]
public class FoodPreview: MyPreview
{
    public override Type Type => typeof (FoodProperty);
}

/*[CustomEditor(typeof (IngredientProperty))]
[CanEditMultipleObjects]
public class IngredientPreview: MyPreview
{
    public override Type Type => typeof (IngredientProperty);
}*/

[CustomEditor(typeof (CustomerProperty))]
[CanEditMultipleObjects]
public class CustomerPreview: MyPreview
{
    public override Type Type => typeof (CustomerProperty);
}

[CustomEditor(typeof (CookwareProperty))]
[CanEditMultipleObjects]
public class CookwarePreview: MyPreview
{
    public override Type Type => typeof (CookwareProperty);
}