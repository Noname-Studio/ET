using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ET
{
    public sealed class EventSystem: IDisposable
    {
        private static EventSystem instance;

        public static EventSystem Instance => instance ?? (instance = new EventSystem());

        private readonly Dictionary<long, Entity> allComponents = new Dictionary<long, Entity>();

        private readonly Dictionary<string, Assembly> assemblies = new Dictionary<string, Assembly>();

        private readonly UnOrderMultiMapSet<Type, Type> types = new UnOrderMultiMapSet<Type, Type>();

        private readonly Dictionary<Type, List<object>> allEvents = new Dictionary<Type, List<object>>();

        private readonly UnOrderMultiMap<Type, IAwakeSystem> awakeSystems = new UnOrderMultiMap<Type, IAwakeSystem>();

        private readonly UnOrderMultiMap<Type, IStartSystem> startSystems = new UnOrderMultiMap<Type, IStartSystem>();

        private readonly UnOrderMultiMap<Type, IDestroySystem> destroySystems = new UnOrderMultiMap<Type, IDestroySystem>();

        private readonly UnOrderMultiMap<Type, ILoadSystem> loadSystems = new UnOrderMultiMap<Type, ILoadSystem>();

        private readonly UnOrderMultiMap<Type, IUpdateSystem> updateSystems = new UnOrderMultiMap<Type, IUpdateSystem>();

        private readonly UnOrderMultiMap<Type, ILateUpdateSystem> lateUpdateSystems = new UnOrderMultiMap<Type, ILateUpdateSystem>();

        private readonly UnOrderMultiMap<Type, IChangeSystem> changeSystems = new UnOrderMultiMap<Type, IChangeSystem>();

        private readonly UnOrderMultiMap<Type, IDeserializeSystem> deserializeSystems = new UnOrderMultiMap<Type, IDeserializeSystem>();

        private Queue<long> updates = new Queue<long>();
        private Queue<long> updates2 = new Queue<long>();

        private readonly Queue<long> starts = new Queue<long>();

        private Queue<long> loaders = new Queue<long>();
        private Queue<long> loaders2 = new Queue<long>();

        private Queue<long> lateUpdates = new Queue<long>();
        private Queue<long> lateUpdates2 = new Queue<long>();

        private EventSystem()
        {
            Add(typeof (EventSystem).Assembly);
        }

        public void Add(Assembly assembly)
        {
            assemblies[assembly.ManifestModule.ScopeName] = assembly;
            types.Clear();
            foreach (Assembly value in assemblies.Values)
            {
                foreach (Type type in value.GetTypes())
                {
                    if (type.IsAbstract)
                    {
                        continue;
                    }

                    object[] objects = type.GetCustomAttributes(typeof (BaseAttribute), true);
                    if (objects.Length == 0)
                    {
                        continue;
                    }

                    foreach (BaseAttribute baseAttribute in objects)
                    {
                        types.Add(baseAttribute.AttributeType, type);
                    }
                }
            }

            awakeSystems.Clear();
            lateUpdateSystems.Clear();
            updateSystems.Clear();
            startSystems.Clear();
            loadSystems.Clear();
            changeSystems.Clear();
            destroySystems.Clear();
            deserializeSystems.Clear();

            foreach (Type type in GetTypes(typeof (ObjectSystemAttribute)))
            {
                object obj = Activator.CreateInstance(type);
                switch (obj)
                {
                    case IAwakeSystem objectSystem:
                        awakeSystems.Add(objectSystem.Type(), objectSystem);
                        break;
                    case IUpdateSystem updateSystem:
                        updateSystems.Add(updateSystem.Type(), updateSystem);
                        break;
                    case ILateUpdateSystem lateUpdateSystem:
                        lateUpdateSystems.Add(lateUpdateSystem.Type(), lateUpdateSystem);
                        break;
                    case IStartSystem startSystem:
                        startSystems.Add(startSystem.Type(), startSystem);
                        break;
                    case IDestroySystem destroySystem:
                        destroySystems.Add(destroySystem.Type(), destroySystem);
                        break;
                    case ILoadSystem loadSystem:
                        loadSystems.Add(loadSystem.Type(), loadSystem);
                        break;
                    case IChangeSystem changeSystem:
                        changeSystems.Add(changeSystem.Type(), changeSystem);
                        break;
                    case IDeserializeSystem deserializeSystem:
                        deserializeSystems.Add(deserializeSystem.Type(), deserializeSystem);
                        break;
                }
            }

            allEvents.Clear();
            foreach (Type type in types[typeof (EventAttribute)])
            {
                IEvent obj = Activator.CreateInstance(type) as IEvent;
                if (obj == null)
                {
                    throw new Exception($"type not is AEvent: {obj.GetType().Name}");
                }

                Type eventType = obj.GetEventType();
                if (!allEvents.ContainsKey(eventType))
                {
                    allEvents.Add(eventType, new List<object>());
                }

                allEvents[eventType].Add(obj);
            }

            Load();
        }

        public Assembly GetAssembly(string name)
        {
            return assemblies[name];
        }

        public HashSet<Type> GetTypes(Type systemAttributeType)
        {
            if (!types.ContainsKey(systemAttributeType))
            {
                return new HashSet<Type>();
            }

            return types[systemAttributeType];
        }

        public List<Type> GetTypes()
        {
            List<Type> allTypes = new List<Type>();
            foreach (Assembly assembly in assemblies.Values)
            {
                allTypes.AddRange(assembly.GetTypes());
            }

            return allTypes;
        }

        public void RegisterSystem(Entity component, bool isRegister = true)
        {
            if (!isRegister)
            {
                Remove(component.InstanceId);
                return;
            }

            allComponents.Add(component.InstanceId, component);

            Type type = component.GetType();

            if (loadSystems.ContainsKey(type))
            {
                loaders.Enqueue(component.InstanceId);
            }

            if (updateSystems.ContainsKey(type))
            {
                updates.Enqueue(component.InstanceId);
            }

            if (startSystems.ContainsKey(type))
            {
                starts.Enqueue(component.InstanceId);
            }

            if (lateUpdateSystems.ContainsKey(type))
            {
                lateUpdates.Enqueue(component.InstanceId);
            }
        }

        public void Remove(long instanceId)
        {
            allComponents.Remove(instanceId);
        }

        public Entity Get(long instanceId)
        {
            Entity component = null;
            allComponents.TryGetValue(instanceId, out component);
            return component;
        }

        public bool IsRegister(long instanceId)
        {
            return allComponents.ContainsKey(instanceId);
        }

        public void Deserialize(Entity component)
        {
            List<IDeserializeSystem> iDeserializeSystems = deserializeSystems[component.GetType()];
            if (iDeserializeSystems == null)
            {
                return;
            }

            foreach (IDeserializeSystem deserializeSystem in iDeserializeSystems)
            {
                if (deserializeSystem == null)
                {
                    continue;
                }

                try
                {
                    deserializeSystem.Run(component);
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }

        public void Awake(Entity component)
        {
            List<IAwakeSystem> iAwakeSystems = awakeSystems[component.GetType()];
            if (iAwakeSystems == null)
            {
                return;
            }

            foreach (IAwakeSystem aAwakeSystem in iAwakeSystems)
            {
                if (aAwakeSystem == null)
                {
                    continue;
                }

                IAwake iAwake = aAwakeSystem as IAwake;
                if (iAwake == null)
                {
                    continue;
                }

                try
                {
                    iAwake.Run(component);
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }

        public void Awake<P1>(Entity component, P1 p1)
        {
            List<IAwakeSystem> iAwakeSystems = awakeSystems[component.GetType()];
            if (iAwakeSystems == null)
            {
                return;
            }

            foreach (IAwakeSystem aAwakeSystem in iAwakeSystems)
            {
                if (aAwakeSystem == null)
                {
                    continue;
                }

                IAwake<P1> iAwake = aAwakeSystem as IAwake<P1>;
                if (iAwake == null)
                {
                    continue;
                }

                try
                {
                    iAwake.Run(component, p1);
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }

        public void Awake<P1, P2>(Entity component, P1 p1, P2 p2)
        {
            List<IAwakeSystem> iAwakeSystems = awakeSystems[component.GetType()];
            if (iAwakeSystems == null)
            {
                return;
            }

            foreach (IAwakeSystem aAwakeSystem in iAwakeSystems)
            {
                if (aAwakeSystem == null)
                {
                    continue;
                }

                IAwake<P1, P2> iAwake = aAwakeSystem as IAwake<P1, P2>;
                if (iAwake == null)
                {
                    continue;
                }

                try
                {
                    iAwake.Run(component, p1, p2);
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }

        public void Awake<P1, P2, P3>(Entity component, P1 p1, P2 p2, P3 p3)
        {
            List<IAwakeSystem> iAwakeSystems = awakeSystems[component.GetType()];
            if (iAwakeSystems == null)
            {
                return;
            }

            foreach (IAwakeSystem aAwakeSystem in iAwakeSystems)
            {
                if (aAwakeSystem == null)
                {
                    continue;
                }

                IAwake<P1, P2, P3> iAwake = aAwakeSystem as IAwake<P1, P2, P3>;
                if (iAwake == null)
                {
                    continue;
                }

                try
                {
                    iAwake.Run(component, p1, p2, p3);
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }

        public void Awake<P1, P2, P3, P4>(Entity component, P1 p1, P2 p2, P3 p3, P4 p4)
        {
            List<IAwakeSystem> iAwakeSystems = awakeSystems[component.GetType()];
            if (iAwakeSystems == null)
            {
                return;
            }

            foreach (IAwakeSystem aAwakeSystem in iAwakeSystems)
            {
                if (aAwakeSystem == null)
                {
                    continue;
                }

                IAwake<P1, P2, P3, P4> iAwake = aAwakeSystem as IAwake<P1, P2, P3, P4>;
                if (iAwake == null)
                {
                    continue;
                }

                try
                {
                    iAwake.Run(component, p1, p2, p3, p4);
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }

        public void Change(Entity component)
        {
            List<IChangeSystem> iChangeSystems = changeSystems[component.GetType()];
            if (iChangeSystems == null)
            {
                return;
            }

            foreach (IChangeSystem iChangeSystem in iChangeSystems)
            {
                if (iChangeSystem == null)
                {
                    continue;
                }

                try
                {
                    iChangeSystem.Run(component);
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }

        public void Load()
        {
            while (loaders.Count > 0)
            {
                long instanceId = loaders.Dequeue();
                Entity component;
                if (!allComponents.TryGetValue(instanceId, out component))
                {
                    continue;
                }

                if (component.IsDisposed)
                {
                    continue;
                }

                List<ILoadSystem> iLoadSystems = loadSystems[component.GetType()];
                if (iLoadSystems == null)
                {
                    continue;
                }

                loaders2.Enqueue(instanceId);

                foreach (ILoadSystem iLoadSystem in iLoadSystems)
                {
                    try
                    {
                        iLoadSystem.Run(component);
                    }
                    catch (Exception e)
                    {
                        Log.Error(e);
                    }
                }
            }

            ObjectHelper.Swap(ref loaders, ref loaders2);
        }

        private void Start()
        {
            while (starts.Count > 0)
            {
                long instanceId = starts.Dequeue();
                Entity component;
                if (!allComponents.TryGetValue(instanceId, out component))
                {
                    continue;
                }

                List<IStartSystem> iStartSystems = startSystems[component.GetType()];
                if (iStartSystems == null)
                {
                    continue;
                }

                foreach (IStartSystem iStartSystem in iStartSystems)
                {
                    try
                    {
                        iStartSystem.Run(component);
                    }
                    catch (Exception e)
                    {
                        Log.Error(e);
                    }
                }
            }
        }

        public void Destroy(Entity component)
        {
            List<IDestroySystem> iDestroySystems = destroySystems[component.GetType()];
            if (iDestroySystems == null)
            {
                return;
            }

            foreach (IDestroySystem iDestroySystem in iDestroySystems)
            {
                if (iDestroySystem == null)
                {
                    continue;
                }

                try
                {
                    iDestroySystem.Run(component);
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }

        public void Update()
        {
            Start();

            while (updates.Count > 0)
            {
                long instanceId = updates.Dequeue();
                Entity component;
                if (!allComponents.TryGetValue(instanceId, out component))
                {
                    continue;
                }

                if (component.IsDisposed)
                {
                    continue;
                }

                List<IUpdateSystem> iUpdateSystems = updateSystems[component.GetType()];
                if (iUpdateSystems == null)
                {
                    continue;
                }

                updates2.Enqueue(instanceId);

                foreach (IUpdateSystem iUpdateSystem in iUpdateSystems)
                {
                    try
                    {
                        iUpdateSystem.Run(component);
                    }
                    catch (Exception e)
                    {
                        Log.Error(e);
                    }
                }
            }

            ObjectHelper.Swap(ref updates, ref updates2);
        }

        public void LateUpdate()
        {
            while (lateUpdates.Count > 0)
            {
                long instanceId = lateUpdates.Dequeue();
                Entity component;
                if (!allComponents.TryGetValue(instanceId, out component))
                {
                    continue;
                }

                if (component.IsDisposed)
                {
                    continue;
                }

                List<ILateUpdateSystem> iLateUpdateSystems = lateUpdateSystems[component.GetType()];
                if (iLateUpdateSystems == null)
                {
                    continue;
                }

                lateUpdates2.Enqueue(instanceId);

                foreach (ILateUpdateSystem iLateUpdateSystem in iLateUpdateSystems)
                {
                    try
                    {
                        iLateUpdateSystem.Run(component);
                    }
                    catch (Exception e)
                    {
                        Log.Error(e);
                    }
                }
            }

            ObjectHelper.Swap(ref lateUpdates, ref lateUpdates2);
        }

        public async ETTask Publish<T>(T a) where T : struct
        {
            List<object> iEvents;
            if (!allEvents.TryGetValue(typeof (T), out iEvents))
            {
                return;
            }

            foreach (object obj in iEvents)
            {
                try
                {
                    using (var list = ListComponent<ETTask>.Create())
                    {
                        if (!(obj is AEvent<T> aEvent))
                        {
                            Log.Error($"event error: {obj.GetType().Name}");
                            continue;
                        }

                        list.List.Add(aEvent.Handle(a));

                        await ETTaskHelper.WaitAll(list.List);
                    }
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            HashSet<Type> noParent = new HashSet<Type>();
            Dictionary<Type, int> typeCount = new Dictionary<Type, int>();

            HashSet<Type> noDomain = new HashSet<Type>();

            foreach (var kv in allComponents)
            {
                Type type = kv.Value.GetType();
                if (kv.Value.Parent == null)
                {
                    noParent.Add(type);
                }

                if (kv.Value.Domain == null)
                {
                    noDomain.Add(type);
                }

                if (typeCount.ContainsKey(type))
                {
                    typeCount[type]++;
                }
                else
                {
                    typeCount[type] = 1;
                }
            }

            sb.AppendLine("not set parent type: ");
            foreach (Type type in noParent)
            {
                sb.AppendLine($"\t{type.Name}");
            }

            sb.AppendLine("not set domain type: ");
            foreach (Type type in noDomain)
            {
                sb.AppendLine($"\t{type.Name}");
            }

            IOrderedEnumerable<KeyValuePair<Type, int>> orderByDescending = typeCount.OrderByDescending(s => s.Value);

            sb.AppendLine("Entity Count: ");
            foreach (var kv in orderByDescending)
            {
                if (kv.Value == 1)
                {
                    continue;
                }

                sb.AppendLine($"\t{kv.Key.Name}: {kv.Value}");
            }

            return sb.ToString();
        }

        public void Dispose()
        {
            instance = null;
        }
    }
}