using System.Collections.Generic;
using Cysharp.Threading.Tasks;

/// <summary>
/// 场景加载的接口类.
/// </summary>
public interface ISceneLoading
{
    /// <summary>
    /// 每次切换场景的时候会将外部的参数传递进入这里.你可以在方法中缓存下来.再后续的方法中继续使用
    /// </summary>
    /// <param name="data"></param>
    void InjectParamters(ISceneLoadData data);
    /// <summary>
    /// 你可以在这里准备哪些资源需要被加载.也可以在这里下载某些后续需要使用到的资源
    /// 即使这里不添加所有的加载资源也没关系.
    /// 这个函数更多的是判断文件完整性和是否存在.
    /// 同时如果加载这个场景的时候检查这个函数返回的所有AB如果再之前场景加载过.则保证之前场景加载的AB不会被卸载,避免重复加载
    /// </summary>
    /// <returns></returns>
    List<string> PreparedResources();
    /// <summary>
    /// 运行你创建场景的逻辑.创建需要的东西
    /// </summary>
    /// <returns></returns>
    UniTask Run();
    /// <summary>
    /// 这里我们建议返回要卸载的AB包.这样在下一次PreparedResources的时候我们可以根据需要过滤相应的需要卸载的包.避免重复加载AB
    /// </summary>
    /// <returns></returns>
    UniTask Release();
}
