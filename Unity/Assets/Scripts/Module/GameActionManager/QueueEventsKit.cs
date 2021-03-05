using System.Collections.Generic;

/// <summary>
/// 按顺序执行事件的管理器
/// </summary>
public class QueueEventsKit
{
    private List<IGameAction> mGameActions = new List<IGameAction>();
    private Dictionary<IGameAction, bool> Init = new Dictionary<IGameAction, bool>();
    private static QueueEventsKit _inst;
    public static QueueEventsKit Inst => _inst ?? (_inst = new QueueEventsKit());
    
    private QueueEventsKit()
    {
        UnityLifeCycleKit.Inst.AddUpdate(Update);
    }
    
    /// <summary>
    /// 插入到执行队列的最前面.
    /// </summary>
    /// <param name="action"></param>
    public void AddToTop(IGameAction action)
    {
        mGameActions.Add(action);
        Init.Add(action,false);
    }

    /// <summary>
    /// 插入到执行队列的尾部
    /// </summary>
    /// <param name="action"></param>
    public void AddToBottom(IGameAction action)
    {
        mGameActions.Insert(0,action);
        Init.Add(action,false);
    }

    private float Update()
    {
        while(mGameActions.Count > 0)
        {
            int i = mGameActions.Count - 1;
            var action = mGameActions[i];
            if (Init.TryGetValue(action, out bool init))
            {
                if (init == false)
                {
                    action.Execute();
                    Init[action] = true;
                }
            }
            bool isDone = action.Update();
            if (!isDone)
                break;
            else
            {
                mGameActions.RemoveAt(i);
                Init.Remove(action);
            }
        }

        return 0;
    }
}
