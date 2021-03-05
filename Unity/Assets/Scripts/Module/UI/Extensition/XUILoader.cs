using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using FairyGUI;
using FairyGUI.Utils;
using Panthea.Asset;
using UnityEngine;
using UnityEngine.Networking;

public class XUILoader : GLoader
{
    public static Dictionary<string, Stack<XUILoader>> LoaderPool = new Dictionary<string, Stack<XUILoader>>();
    
    /// <summary>
    /// 是否从网络上加载.一般从网络上加载得图片.我们用完就直接卸载就行了
    /// </summary>
    private bool LoadFromUrl;

    private const string UrlFlag = "https://";
    /// <summary>
    /// 初始化时赋值得图片
    /// </summary>
    private string DefaultUrl;
    
    public override void Setup_AfterAdd(ByteBuffer buffer, int beginPos)
    {
        base.Setup_AfterAdd(buffer, beginPos);
        DefaultUrl = url;
    }

    /// <summary>
    /// 扩展卸载
    /// </summary>
    protected override void FreeExternal(NTexture texture)
    {
        base.FreeExternal(texture);
        if (url!= null&& url.StartsWith(UrlFlag))
        {
            texture.Dispose();
        }
    }

    public override void Dispose()
    {
        base.Dispose();
    }

    /// <summary>
    /// 扩展加载
    /// </summary>
    protected override async void LoadExternal()
    {
        if (displayObject?.cachedTransform == null)
            return;
        if (url.StartsWith(UrlFlag))
        {
            if (!string.IsNullOrEmpty(DefaultUrl))
                LoadFromPackage(DefaultUrl);
            NTexture tex = await LoadFromInternet();
            if (tex == null)
                return;
            tex.destroyMethod = DestroyMethod.Unload;
            onExternalLoadSuccess(tex);
            LoadFromUrl = true;
            return;
        }
        Texture texture;
        texture = await AssetsKit.Inst.Load<Texture>(url);
        if (texture == null)
        {
            texture = Resources.Load<Texture>(url);
        }
        if (texture != null)
        {
            var addNTex = new NTexture(texture);
            onExternalLoadSuccess(addNTex);
        }
        else
        {
            Log.Error("Resources.Load 找不到该文件" + "     " + url);
        }
    }
    
    private async Task<NTexture> LoadFromInternet()
    {
        string savePath = "Network/";
        string fileName = "";
        if (url.StartsWith($"https://graph.facebook.com/"))
        {
            //Facebook的外链
            savePath += "Facebook/";
            fileName = url.Remove(0, $"https://graph.facebook.com/".Length);
            fileName = fileName.Remove(fileName.IndexOf("/"));
        }

        var tex = await LoadTextureFromDisk(savePath + fileName);
        if (tex == null)
        {
            using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(url))
            {
                var operation = request.SendWebRequest();
                await operation;
                if (request.isNetworkError || request.isHttpError)
                {
                    Log.Print(request.error + "    " + request.responseCode + "    " + url);
                }
                else
                {
                    tex = DownloadHandlerTexture.GetContent(request);
                    SaveTextureToDisk(tex, savePath, fileName);
                    return new NTexture(tex);
                }
            }
        }
        else
        {
            return new NTexture(tex);
        }
        return null;
    }

    private async Task<Texture2D> LoadTextureFromDisk(string url)
    {
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(AssetsConfig.PersistentDataPath + url))
        {
            var operation = request.SendWebRequest();
            await operation;
            if (request.isNetworkError || request.isHttpError)
            {
                Log.Print(request.error + "    " + request.responseCode + "    " + url);
            }
            else
            {
                var texture = DownloadHandlerTexture.GetContent(request);
                return texture;
            }
        }

        return null;
    }
    
    private void SaveTextureToDisk(Texture2D texture,string path,string fileName)
    {
        var dir = AssetsConfig.PersistentDataPath + path;
        var bytes = texture.EncodeToPNG();
        if (!Directory.Exists(dir))
        {
            //Debugger.Log($"创建文件夹 {dir}");
            Directory.CreateDirectory(dir);
        }

        var filePath = dir + fileName;
        if (File.Exists(filePath))
        {
            //Debugger.Log($"检测到文件 {writeFilePath}已经存在,删除！！");
            File.Delete(filePath);
        }
        using (FileStream file = new FileStream(filePath,FileMode.CreateNew))
        {
            //Debugger.Log($"写入文件{writeFilePath}");
            file.Write(bytes, 0, bytes.Length);
        }
    }

    public void WrapComponent(GComponent com)
    {
        ((Container)displayObject).AddChild(com.displayObject);
        UpdateLayout();
    }
}
