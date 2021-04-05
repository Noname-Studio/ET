using System;
using System.Collections.Generic;
using System.IO;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Animations;
#endif
using UnityEngine;

[DisallowMultipleComponent]
public class CommonStateMachineBehaviour: StateMachineBehaviour
{
    public delegate void StateEvent(AnimatorControl animator, AnimatorStateInfo stateInfo, int layerIndex);

    public AnimatorControl Control;

    [Serializable]
    public class StateInfo
    {
        [SerializeField]
        [LabelText("Name")]
        [ReadOnly]
        private string mName;

        [SerializeField]
        [LabelText("Hash")]
        [ReadOnly]
        private int mHash;

        [SerializeField]
        [LabelText("Clip")]
        [ReadOnly]
        private AnimationClip mClip;

        public string Name => mName;
        public int Hash => mHash;
        public AnimationClip Clip => mClip;

        public StateInfo(string name, int hash, AnimationClip clip)
        {
            mName = name;
            mHash = hash;
        }
    }

    [Serializable]
    public class LayerInfo
    {
        public string Name;
        public int Index;
    }

    [Serializable]
    public class AnimatorRuntimeInfo
    {
        public List<StateInfo> StateInfo;
        public LayerInfo Layer;

        public StateInfo FindState(string stateName)
        {
            foreach (var node in StateInfo)
            {
                if (node.Name.Equals(stateName, StringComparison.OrdinalIgnoreCase))
                {
                    return node;
                }
            }

            return null;
        }

        public StateInfo FindState(int stateHash)
        {
            foreach (var node in StateInfo)
            {
                if (node.Hash == stateHash)
                {
                    return node;
                }
            }

            return null;
        }
    }

    public class ActiveState
    {
        public StateInfo State;

        /// <summary>
        /// 这个是给内部使用得.
        /// 因为Unity只有在过渡结束得时候才会触发Exit事件
        /// 我们希望在任何时候状态变化都能触发Exit事件
        /// </summary>
        public bool HasTriggerExit;

        public AnimatorStateInfo StateInfo;
    }

    private Dictionary<int, List<StateEvent>> EnterEvents = new Dictionary<int, List<StateEvent>>();
    private Dictionary<int, List<StateEvent>> RunningEvents = new Dictionary<int, List<StateEvent>>();
    private Dictionary<int, List<StateEvent>> ExitEvents = new Dictionary<int, List<StateEvent>>();

    public AnimatorRuntimeInfo RuntimeInfo = new AnimatorRuntimeInfo();
    public ActiveState CurrentState;
    private int? PrevTiggerAnimation { get; set; } = null;
    public void AddEvent(AnimatorEventType type, StateEvent action, string stateName)
    {
        var state = RuntimeInfo.FindState(stateName);
        if (state == null)
        {
            Log.Error($"{stateName}状态不存在");
            return;
        }

        int hash = state.Hash;
        List<StateEvent> eventValue;
        switch (type)
        {
            case AnimatorEventType.Enter:
                if (!EnterEvents.TryGetValue(hash, out eventValue))
                {
                    EnterEvents.Add(hash, eventValue = new List<StateEvent>());
                }

                eventValue.Add(action);
                break;
            case AnimatorEventType.Exit:
                if (!ExitEvents.TryGetValue(hash, out eventValue))
                {
                    ExitEvents.Add(hash, eventValue = new List<StateEvent>());
                }

                eventValue.Add(action);
                break;
            case AnimatorEventType.Running:
                if (!RunningEvents.TryGetValue(hash, out eventValue))
                {
                    RunningEvents.Add(hash, eventValue = new List<StateEvent>());
                }

                eventValue.Add(action);
                break;
            default:
                Log.Error("类型不存在无法添加事件");
                break;
        }
    }

    public void RemoveEvent(AnimatorEventType type, StateEvent action, string stateName)
    {
        var state = RuntimeInfo.FindState(stateName);
        if (state == null)
        {
            Log.Error($"{stateName}状态不存在");
            return;
        }

        int hash = state.Hash;
        List<StateEvent> eventValue;
        switch (type)
        {
            case AnimatorEventType.Enter:
                if (EnterEvents.TryGetValue(hash, out eventValue))
                {
                    eventValue.Remove(action);
                }

                break;
            case AnimatorEventType.Exit:
                if (ExitEvents.TryGetValue(hash, out eventValue))
                {
                    eventValue.Remove(action);
                }

                break;
            case AnimatorEventType.Running:
                if (RunningEvents.TryGetValue(hash, out eventValue))
                {
                    eventValue.Remove(action);
                }

                break;
            default:
                Log.Error("类型不存在无法删除事件");
                break;
        }
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PrevTiggerAnimation = null;
        var state = RuntimeInfo.FindState(stateInfo.shortNameHash);
        if (state == null)
        {
            Log.Error("状态不存在请检查原因");
            return;
        }

        if (CurrentState == null)
        {
            CurrentState = new ActiveState();
        }
        /*else
        {
            if (!CurrentState.HasTriggerExit)
            {
                OnStateExit(animator, CurrentState.StateInfo, layerIndex);
            }
        }*/

        CurrentState.HasTriggerExit = false;
        CurrentState.State = state;
        CurrentState.StateInfo = stateInfo;
        List<StateEvent> @event;
        if (EnterEvents.TryGetValue(stateInfo.shortNameHash, out @event))
        {
            for (int i = 0; i < @event.Count; i++)
            {
                @event[i](Control, stateInfo, layerIndex);
            }
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        List<StateEvent> @event;
        if (RunningEvents.TryGetValue(stateInfo.shortNameHash, out @event))
        {
            for (int i = 0; i < @event.Count; i++)
            {
                @event[i](Control, stateInfo, layerIndex);
            }
        }

        if (stateInfo.normalizedTime > 1)
        {
            if (PrevTiggerAnimation != stateInfo.shortNameHash)
            {
                if (ExitEvents.TryGetValue(stateInfo.shortNameHash, out @event))
                {
                    for (int i = 0; i < @event.Count; i++)
                    {
                        @event[i](Control, stateInfo, layerIndex);
                        PrevTiggerAnimation = stateInfo.shortNameHash;
                    }
                }
            }

        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (CurrentState != null)
        {
            CurrentState.HasTriggerExit = true;
        }

        List<StateEvent> @event;
        if (ExitEvents.TryGetValue(stateInfo.shortNameHash, out @event))
        {
            for (int i = 0; i < @event.Count; i++)
            {
                @event[i](Control, stateInfo, layerIndex);
            }
        }
    }
}

#region 编辑器代码

#if UNITY_EDITOR
public class CommonStateMachineBehaviourEditor: AssetPostprocessor
{
    private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        int length = importedAssets.Length;
        for (int i = 0; i < length; i++)
        {
            var import = importedAssets[i];
            if (Path.GetExtension(import) == ".controller")
            {
                AnimatorController controller = AssetDatabase.LoadAssetAtPath<AnimatorController>(import);
                Run(controller);
            }
        }
    }

    public static void Run(AnimatorController animatorController)
    {
        if (animatorController != null)
        {
            for (int i = 0; i < animatorController.layers.Length; i++)
            {
                AnimatorStateMachine stateMachine = animatorController.layers[i].stateMachine;
                var behaviour = AddBehaviour(stateMachine);
                ResetBehaviour(behaviour);
                InitBehaviourStateInfo(stateMachine, behaviour);
                InitBehaviourLayerInfo(stateMachine, behaviour, i);
                EditorUtility.SetDirty(behaviour);
            }
        }
    }

    private static void ResetBehaviour(CommonStateMachineBehaviour behaviour)
    {
        behaviour.RuntimeInfo = new CommonStateMachineBehaviour.AnimatorRuntimeInfo();
        behaviour.RuntimeInfo.StateInfo = new List<CommonStateMachineBehaviour.StateInfo>();
        behaviour.RuntimeInfo.Layer = new CommonStateMachineBehaviour.LayerInfo();
    }

    private static CommonStateMachineBehaviour AddBehaviour(AnimatorStateMachine sm)
    {
        bool needAddBehaviours = true;
        foreach (StateMachineBehaviour node in sm.behaviours)
        {
            if (node is CommonStateMachineBehaviour)
            {
                return (CommonStateMachineBehaviour) node;
            }
        }

        return sm.AddStateMachineBehaviour<CommonStateMachineBehaviour>();
    }

    private static void InitBehaviourStateInfo(AnimatorStateMachine machine, CommonStateMachineBehaviour state, string layer = "")
    {
        foreach (var sms in machine.stateMachines)
        {
            var node = sms.stateMachine;
            InitBehaviourStateInfo(node, state, node.name + ".");
        }

        foreach (var node in machine.states)
        {
            state.RuntimeInfo.StateInfo.Add(new CommonStateMachineBehaviour.StateInfo(node.state.name, Animator.StringToHash(node.state.name),
                (AnimationClip) node.state.motion));
        }
    }

    private static void InitBehaviourLayerInfo(AnimatorStateMachine machine, CommonStateMachineBehaviour state, int layer)
    {
        state.RuntimeInfo.Layer.Name = machine.name;
        state.RuntimeInfo.Layer.Index = layer;
    }
}
#endif

#endregion