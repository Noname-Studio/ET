using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;

public enum AnimatorEventType
{
    Enter,
    Exit,
    Running
}

[RequireComponent(typeof (Animator))]
[DefaultExecutionOrder(99)]
public partial class AnimatorControl: MonoBehaviour
{
    private Animator mAnimator;

    public Animator Animator
    {
        get
        {
            return (object) mAnimator != null? mAnimator : (mAnimator = GetComponent<Animator>());
        }
        private set
        {
            mAnimator = value;
        }
    }

    public float Speed
    {
        get
        {
            return Animator.speed;
        }
        set
        {
            Animator.speed = value;
        }
    }

    private const string MatchSign = "*";
    private const string RandomSign = "?";
    private Dictionary<int, CommonStateMachineBehaviour> mBehaviour = new Dictionary<int, CommonStateMachineBehaviour>();

    public CommonStateMachineBehaviour GetBehaviour(int layer)
    {
        CommonStateMachineBehaviour state;
        if (!mBehaviour.TryGetValue(layer, out state))
        {
            Log.Error("不存在这个动画层");
            return null;
        }

        return state;
    }

    public string PlayingAnimation
    {
        get
        {
            var info = GetBehaviour(0)?.CurrentState?.StateInfo;
            if (info.HasValue)
                return HashToName(info.Value.shortNameHash);
            return "";
        }
    }

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        ReApplyStateMachine();
    }

    private void ReApplyStateMachine()
    {
        var allState = Animator.GetBehaviours<CommonStateMachineBehaviour>();
        mBehaviour.Clear();
        foreach (var node in allState)
        {
            mBehaviour.Add(node.RuntimeInfo.Layer.Index, node);
            node.Control = this;
        }
    }

    public bool HasAnimation(string name)
    {
        foreach (var node in GetBehaviour(0).RuntimeInfo.StateInfo)
        {
            if (node.Name == name)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// 使用*表示将Action应用到所有的状态当中
    /// 使用如Attack_*表示所有带有Attack_前缀的添加Action
    /// 当不带*时表示全字符匹配
    /// </summary>
    public void SetEvent(AnimatorEventType type, CommonStateMachineBehaviour.StateEvent action, params string[] stateName)
    {
        AddEvent(type, action, 0, stateName);
    }

    public void AddEvent(AnimatorEventType type, CommonStateMachineBehaviour.StateEvent action, int layer, params string[] stateName)
    {
        int length = stateName.Length;
        var behaviour = GetBehaviour(layer);
        var stateInfo = behaviour.RuntimeInfo.StateInfo;
        for (int i = 0; i < length; i++)
        {
            if (string.IsNullOrEmpty(stateName[i]))
                continue;
            if (stateName[i].Contains(MatchSign))
            {
                if (stateName[i].Length == 1)
                {
                    for (int j = 0; j < stateInfo.Count; j++)
                    {
                        behaviour.AddEvent(type, action, stateInfo[j].Name);
                    }
                }
                else
                {
                    stateName[i] = stateName[i].Replace(MatchSign, "");
                    for (int j = 0; j < stateInfo.Count; j++)
                    {
                        var name = stateInfo[j].Name;
                        var index = name.IndexOf(stateName[i]);
                        if (index != -1)
                        {
                            behaviour.AddEvent(type, action, name);
                        }
                    }
                }
            }
            else
            {
                behaviour.AddEvent(type, action, stateName[i]);
            }
        }
    }

    /// <summary>
    /// 使用*表示将Action应用到所有的状态当中
    /// 使用如Attack_*表示所有带有Attack_前缀的添加Action
    /// 当不带*时表示全字符匹配
    /// </summary>
    public void RemoveEvent(AnimatorEventType type, CommonStateMachineBehaviour.StateEvent action, params string[] stateName)
    {
        RemoveEvent(type, action, 0, stateName);
    }

    public void RemoveEvent(AnimatorEventType type, CommonStateMachineBehaviour.StateEvent action, int layer, params string[] stateName)
    {
        int length = stateName.Length;
        var behaviour = GetBehaviour(layer);
        var stateInfo = behaviour.RuntimeInfo.StateInfo;
        for (int i = 0; i < length; i++)
        {
            if (string.IsNullOrEmpty(stateName[i]))
                continue;
            if (stateName[i].Contains(MatchSign))
            {
                if (stateName[i].Length == 1)
                {
                    for (int j = 0; j < stateInfo.Count; j++)
                    {
                        behaviour.RemoveEvent(type, action, stateInfo[j].Name);
                    }
                }
                else
                {
                    stateName[i] = stateName[i].Replace(MatchSign, "");
                    for (int j = 0; j < stateInfo.Count; j++)
                    {
                        var name = stateInfo[j].Name;
                        var index = name.IndexOf(stateName[i]);
                        if (index != -1)
                        {
                            behaviour.RemoveEvent(type, action, name);
                        }
                    }
                }
            }
            else
            {
                behaviour.RemoveEvent(type, action, stateName[i]);
            }
        }
    }

    public string HashToName(int hash)
    {
        var state = GetBehaviour(0).RuntimeInfo.FindState(hash);
        if (state != null)
            return state.Name;
        Log.Error("不存在这个Hash:" + hash);
        return "";
    }

    public void ReplaceController(RuntimeAnimatorController animatorController)
    {
        Animator.runtimeAnimatorController = animatorController;
        ReApplyStateMachine();
    }

    #region 重写方法

    /// <summary>
    /// 你可以使用?来随机动画的播放
    /// 如Attack_?则会随机播放所有带有Attack_为前缀的任意动画
    /// </summary>
    public void Play(string anim, int layer = 0, float time = 0, bool replay = true)
    {
        Animator.Play(anim, layer, time);
    }

    public void CrossFadeInFixedTime(string anim, float normalizedTransitionDuration, int layer = 0, float normalizedTimeOffset = 0,
    float normalizedTransitionTime = 0, bool replay = true)
    {
        Animator.CrossFadeInFixedTime(anim, normalizedTransitionDuration, layer, normalizedTimeOffset, normalizedTransitionTime);
    }

    /// <summary>
    /// 你可以使用?来随机动画的播放
    /// 如Attack_?则会随机播放所有带有Attack_为前缀的任意动画
    /// </summary>
    public async Task PlayAsync(string anim, int layer = 0, float time = 0, bool replay = true)
    {
        Animator.Play(anim, layer, time);
        TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
        CommonStateMachineBehaviour.StateEvent callback = null;
        callback = (animator, info, index) =>
        {
            RemoveEvent(AnimatorEventType.Exit, callback, anim);
            tcs.SetResult(true);
        };
        SetEvent(AnimatorEventType.Exit, callback, anim);
        await tcs.Task;
    }

    /// <summary>
    /// 你可以使用?来随机动画的播放
    /// 如Attack_?则会随机播放所有带有Attack_为前缀的任意动画
    /// </summary>
    public async Task CrossFadeInFixedTimeAsync(string anim, float normalizedTransitionDuration, int layer = 0, float normalizedTimeOffset = 0,
    float normalizedTransitionTime = 0, bool replay = true)
    {
        Animator.CrossFadeInFixedTime(anim, normalizedTransitionDuration, layer, normalizedTimeOffset, normalizedTransitionTime);
        TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
        CommonStateMachineBehaviour.StateEvent callback = null;
        callback = (animator, info, index) =>
        {
            RemoveEvent(AnimatorEventType.Exit, callback, anim);
            tcs.SetResult(true);
        };
        SetEvent(AnimatorEventType.Exit, callback, anim);
        await tcs.Task;
    }

    public event Action<AnimatorControl, string, bool> ParametersBoolChange;

    public void SetBool(string varName, bool value)
    {
        if (string.IsNullOrEmpty(varName))
            return;
        Animator.SetBool(varName, value);
        if (ParametersBoolChange != null) ParametersBoolChange(this, varName, value);
    }

    public event Action<AnimatorControl, string, int> ParametersIntegerChange;

    public void SetInteger(string varName, int value)
    {
        if (string.IsNullOrEmpty(varName))
            return;
        Animator.SetInteger(varName, value);
        if (ParametersIntegerChange != null) ParametersIntegerChange(this, varName, value);
    }

    public event Action<AnimatorControl, string, float> ParametersFloatChange;

    public void SetFloat(string varName, float value)
    {
        if (string.IsNullOrEmpty(varName))
            return;
        Animator.SetFloat(varName, value);
        if (ParametersFloatChange != null) ParametersFloatChange(this, varName, value);
    }

    public event Action<AnimatorControl, string> ParametersTriggerChange;

    public void SetTrigger(string varName)
    {
        if (string.IsNullOrEmpty(varName))
            return;
        Animator.SetTrigger(varName);
        if (ParametersTriggerChange != null) ParametersTriggerChange(this, varName);
    }

    public bool GetBool(string varName)
    {
        return Animator.GetBool(varName);
    }

    public int GetInteger(string varName)
    {
        return Animator.GetInteger(varName);
    }

    public float GetFloat(string varName)
    {
        return Animator.GetFloat(varName);
    }

    #endregion
}