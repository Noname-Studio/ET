using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Pathfinding;
using UnityEngine;

public class KitchenMoveProvider
{
    private GameObject mPathObject;
    private AstarPath mStarPath;
    public KitchenMoveProvider()
    {
        mPathObject = new GameObject("Pathfinding");
        mStarPath = mPathObject.AddComponent<AstarPath>();
        mStarPath.logPathResults = PathLog.None;
        InitPathConfig();
    }

    private void InitPathConfig()
    {
        //await UniTask.NextFrame();
        var graph = (GridGraph)mStarPath.data.AddGraph(typeof(GridGraph));
        
        //TODO 应该改成使用配置表的形式,而不是硬编码
        {
            graph.center = new Vector3(0.3f, -1f);
            graph.SetDimensions(20, 3, 0.33f);
        }
        
        graph.rotation = new Vector3(graph.rotation.y - 90, 270, 90);
        graph.collision.use2D = true;
        graph.Scan();
    }
}
