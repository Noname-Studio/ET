using System;
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
        var graph = (RecastGraph) mStarPath.data.AddGraph(typeof (RecastGraph));

        //TODO 应该改成使用配置表的形式,而不是硬编码
        {
            graph.SnapForceBoundsToScene();
            graph.characterRadius = 0.4f;
            graph.cellSize = 0.15f;
            graph.mask = graph.mask & ~(1 << LayerHelper.IngoreNav);
        }

        graph.Scan();
    }
}