using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

#if !SERVER

#endif

namespace ET
{
    [Flags]
    public enum EntityStatus: byte
    {
        None = 0,
        IsFromPool = 1,
        IsRegister = 1 << 1,
        IsComponent = 1 << 2,
        IsCreate = 1 << 3
    }

    public partial class Entity: Object
    {
        [IgnoreDataMember]
        private static readonly Pool<HashSet<Entity>> hashSetPool = new Pool<HashSet<Entity>>();

        [IgnoreDataMember]
        private static readonly Pool<Dictionary<Type, Entity>> dictPool = new Pool<Dictionary<Type, Entity>>();

        [IgnoreDataMember]
        private static readonly Pool<Dictionary<long, Entity>> childrenPool = new Pool<Dictionary<long, Entity>>();

        [IgnoreDataMember]
        [BsonIgnore]
        public long InstanceId { get; set; }

        protected Entity()
        {
        }

        [IgnoreDataMember]
        [BsonIgnore]
        private EntityStatus status = EntityStatus.None;

        [IgnoreDataMember]
        [BsonIgnore]
        public bool IsFromPool
        {
            get => (status & EntityStatus.IsFromPool) == EntityStatus.IsFromPool;
            set
            {
                if (value)
                {
                    status |= EntityStatus.IsFromPool;
                }
                else
                {
                    status &= ~EntityStatus.IsFromPool;
                }
            }
        }

        [IgnoreDataMember]
        [BsonIgnore]
        public bool IsRegister
        {
            get => (status & EntityStatus.IsRegister) == EntityStatus.IsRegister;
            set
            {
                if (IsRegister == value)
                {
                    return;
                }

                if (value)
                {
                    status |= EntityStatus.IsRegister;
                }
                else
                {
                    status &= ~EntityStatus.IsRegister;
                }

                EventSystem.Instance.RegisterSystem(this, value);
            }
        }

        [IgnoreDataMember]
        [BsonIgnore]
        private bool IsComponent
        {
            get => (status & EntityStatus.IsComponent) == EntityStatus.IsComponent;
            set
            {
                if (value)
                {
                    status |= EntityStatus.IsComponent;
                }
                else
                {
                    status &= ~EntityStatus.IsComponent;
                }
            }
        }

        [IgnoreDataMember]
        [BsonIgnore]
        public bool IsCreate
        {
            get => (status & EntityStatus.IsCreate) == EntityStatus.IsCreate;
            set
            {
                if (value)
                {
                    status |= EntityStatus.IsCreate;
                }
                else
                {
                    status &= ~EntityStatus.IsCreate;
                }
            }
        }

        [IgnoreDataMember]
        [BsonIgnore]
        public bool IsDisposed => InstanceId == 0;

        [IgnoreDataMember]
        [BsonIgnore]
        protected Entity parent;

        [IgnoreDataMember]
        [BsonIgnore]
        public Entity Parent
        {
            get => parent;
            set
            {
                if (value == null)
                {
                    throw new Exception($"cant set parent null: {GetType().Name}");
                }

                if (parent != null) // 之前有parent
                {
                    // parent相同，不设置
                    if (parent.InstanceId == value.InstanceId)
                    {
                        Log.Error($"重复设置了Parent: {GetType().Name} parent: {parent.GetType().Name}");
                        return;
                    }

                    parent.RemoveChild(this);

                    parent = value;
                    parent.AddChild(this);

                    Domain = parent.domain;
                }
                else
                {
                    parent = value;
                    parent.AddChild(this);

                    IsComponent = false;

                    AfterSetParent();
                }
            }
        }

        [IgnoreDataMember]
        // 该方法只能在AddComponent中调用，其他人不允许调用
        [BsonIgnore]
        private Entity ComponentParent
        {
            set
            {
                if (parent != null)
                {
                    throw new Exception($"Component parent is not null: {GetType().Name}");
                }

                parent = value;

                IsComponent = true;

                AfterSetParent();
            }
        }

        private void AfterSetParent()
        {
            Domain = parent.domain;

#if UNITY_EDITOR && VIEWGO
            if (this.ViewGO != null && this.parent.ViewGO != null)
            {
                this.ViewGO.transform.SetParent(this.parent.ViewGO.transform, false);
            }
#endif
        }

        public T GetParent<T>() where T : Entity
        {
            return Parent as T;
        }

        [BsonIgnoreIfDefault]
        [BsonDefaultValue(0L)]
        [BsonElement]
        [BsonId]
        public long Id { get; set; }

        [IgnoreDataMember]
        [BsonIgnore]
        protected Entity domain;

        [IgnoreDataMember]
        [BsonIgnore]
        public Entity Domain
        {
            get => domain;
            set
            {
                if (value == null)
                {
                    return;
                }

                Entity preDomain = domain;
                domain = value;

                //if (!(this.domain is Scene))
                //{
                //	throw new Exception($"domain is not scene: {this.GetType().Name}");
                //}

                if (preDomain == null)
                {
                    InstanceId = IdGenerater.Instance.GenerateInstanceId();

                    // 反序列化出来的需要设置父子关系
                    if (!IsCreate)
                    {
                        if (componentsDB != null)
                        {
                            foreach (Entity component in componentsDB)
                            {
                                component.IsComponent = true;
                                Components.Add(component.GetType(), component);
                                component.parent = this;
                            }
                        }

                        if (childrenDB != null)
                        {
                            foreach (Entity child in childrenDB)
                            {
                                child.IsComponent = false;
                                Children.Add(child.Id, child);
                                child.parent = this;
                            }
                        }
                    }
                }

                // 是否注册跟parent一致
                if (parent != null)
                {
                    IsRegister = Parent.IsRegister;
                }

                // 递归设置孩子的Domain
                if (children != null)
                {
                    foreach (Entity entity in children.Values)
                    {
                        entity.Domain = domain;
                    }
                }

                if (components != null)
                {
                    foreach (Entity component in components.Values)
                    {
                        component.Domain = domain;
                    }
                }

                if (preDomain == null && !IsCreate)
                {
                    EventSystem.Instance.Deserialize(this);
                }
            }
        }

        [IgnoreDataMember]
        [BsonElement("Children")]
        [BsonIgnoreIfNull]
        private HashSet<Entity> childrenDB;

        [IgnoreDataMember]
        [BsonIgnore]
        private Dictionary<long, Entity> children;

        [IgnoreDataMember]
        [BsonIgnore]
        public Dictionary<long, Entity> Children => children ?? (children = childrenPool.Fetch());

        private void AddChild(Entity entity)
        {
            Children.Add(entity.Id, entity);
            AddChildDB(entity);
        }

        private void RemoveChild(Entity entity)
        {
            if (children == null)
            {
                return;
            }

            children.Remove(entity.Id);

            if (children.Count == 0)
            {
                childrenPool.Recycle(children);
                children = null;
            }

            RemoveChildDB(entity);
        }

        private void AddChildDB(Entity entity)
        {
            if (!(entity is ISerializeToEntity))
            {
                return;
            }

            if (childrenDB == null)
            {
                childrenDB = hashSetPool.Fetch();
            }

            childrenDB.Add(entity);
        }

        private void RemoveChildDB(Entity entity)
        {
            if (!(entity is ISerializeToEntity))
            {
                return;
            }

            if (childrenDB == null)
            {
                return;
            }

            childrenDB.Remove(entity);

            if (childrenDB.Count == 0)
            {
                if (IsFromPool)
                {
                    hashSetPool.Recycle(childrenDB);
                    childrenDB = null;
                }
            }
        }

        [IgnoreDataMember]
        [BsonElement("C")]
        [BsonIgnoreIfNull]
        private HashSet<Entity> componentsDB;

        [IgnoreDataMember]
        [BsonIgnore]
        private Dictionary<Type, Entity> components;

        [IgnoreDataMember]
        [BsonIgnore]
        public Dictionary<Type, Entity> Components => components ?? (components = dictPool.Fetch());

        public override void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            EventSystem.Instance.Remove(InstanceId);
            InstanceId = 0;

            // 清理Component
            if (components != null)
            {
                foreach (KeyValuePair<Type, Entity> kv in components)
                {
                    kv.Value.Dispose();
                }

                components.Clear();
                dictPool.Recycle(components);
                components = null;

                // 从池中创建的才需要回到池中,从db中不需要回收
                if (componentsDB != null)
                {
                    componentsDB.Clear();

                    if (IsFromPool)
                    {
                        hashSetPool.Recycle(componentsDB);
                        componentsDB = null;
                    }
                }
            }

            // 清理Children
            if (children != null)
            {
                foreach (Entity child in children.Values)
                {
                    child.Dispose();
                }

                children.Clear();
                childrenPool.Recycle(children);
                children = null;

                if (childrenDB != null)
                {
                    childrenDB.Clear();
                    // 从池中创建的才需要回到池中,从db中不需要回收
                    if (IsFromPool)
                    {
                        hashSetPool.Recycle(childrenDB);
                        childrenDB = null;
                    }
                }
            }

            // 触发Destroy事件
            EventSystem.Instance.Destroy(this);

            domain = null;

            if (parent != null && !parent.IsDisposed)
            {
                if (IsComponent)
                {
                    parent.RemoveComponent(this);
                }
                else
                {
                    parent.RemoveChild(this);
                }
            }

            parent = null;

            if (IsFromPool)
            {
                ObjectPool.Instance.Recycle(this);
            }
            else
            {
                base.Dispose();
            }

            status = EntityStatus.None;
        }

        private void AddToComponentsDB(Entity component)
        {
            if (componentsDB == null)
            {
                componentsDB = hashSetPool.Fetch();
            }

            componentsDB.Add(component);
        }

        private void RemoveFromComponentsDB(Entity component)
        {
            if (componentsDB == null)
            {
                return;
            }

            componentsDB.Remove(component);
            if (componentsDB.Count == 0 && IsFromPool)
            {
                hashSetPool.Recycle(componentsDB);
                componentsDB = null;
            }
        }

        private void AddToComponent(Type type, Entity component)
        {
            if (components == null)
            {
                components = dictPool.Fetch();
            }

            components.Add(type, component);

            if (component is ISerializeToEntity)
            {
                AddToComponentsDB(component);
            }
        }

        private void RemoveFromComponent(Type type, Entity component)
        {
            if (components == null)
            {
                return;
            }

            components.Remove(type);

            if (components.Count == 0 && IsFromPool)
            {
                dictPool.Recycle(components);
                components = null;
            }

            RemoveFromComponentsDB(component);
        }

        public K GetChild<K>(long id) where K : Entity
        {
            if (children == null)
            {
                return null;
            }

            children.TryGetValue(id, out Entity child);
            return child as K;
        }

        public Entity AddComponent(Entity component)
        {
            Type type = component.GetType();
            if (components != null && components.ContainsKey(type))
            {
                throw new Exception($"entity already has component: {type.FullName}");
            }

            component.ComponentParent = this;

            AddToComponent(type, component);

            return component;
        }

        public Entity AddComponent(Type type)
        {
            if (components != null && components.ContainsKey(type))
            {
                throw new Exception($"entity already has component: {type.FullName}");
            }

            Entity component = CreateWithComponentParent(type);

            AddToComponent(type, component);

            return component;
        }

        public K AddComponent<K>() where K : Entity, new()
        {
            Type type = typeof (K);
            if (components != null && components.ContainsKey(type))
            {
                throw new Exception($"entity already has component: {type.FullName}");
            }

            K component = CreateWithComponentParent<K>();

            AddToComponent(type, component);

            return component;
        }

        public K AddComponent<K, P1>(P1 p1) where K : Entity, new()
        {
            Type type = typeof (K);
            if (components != null && components.ContainsKey(type))
            {
                throw new Exception($"entity already has component: {type.FullName}");
            }

            K component = CreateWithComponentParent<K, P1>(p1);

            AddToComponent(type, component);

            return component;
        }

        public K AddComponent<K, P1, P2>(P1 p1, P2 p2) where K : Entity, new()
        {
            Type type = typeof (K);
            if (components != null && components.ContainsKey(type))
            {
                throw new Exception($"entity already has component: {type.FullName}");
            }

            K component = CreateWithComponentParent<K, P1, P2>(p1, p2);

            AddToComponent(type, component);

            return component;
        }

        public K AddComponent<K, P1, P2, P3>(P1 p1, P2 p2, P3 p3) where K : Entity, new()
        {
            Type type = typeof (K);
            if (components != null && components.ContainsKey(type))
            {
                throw new Exception($"entity already has component: {type.FullName}");
            }

            K component = CreateWithComponentParent<K, P1, P2, P3>(p1, p2, p3);

            AddToComponent(type, component);

            return component;
        }

        public void RemoveComponent<K>() where K : Entity
        {
            if (IsDisposed)
            {
                return;
            }

            if (components == null)
            {
                return;
            }

            Type type = typeof (K);
            Entity c = GetComponent(type);
            if (c == null)
            {
                return;
            }

            RemoveFromComponent(type, c);
            c.Dispose();
        }

        public void RemoveComponent(Entity component)
        {
            if (IsDisposed)
            {
                return;
            }

            if (components == null)
            {
                return;
            }

            Type type = component.GetType();
            Entity c = GetComponent(component.GetType());
            if (c == null)
            {
                return;
            }

            if (c.InstanceId != component.InstanceId)
            {
                return;
            }

            RemoveFromComponent(type, c);
            c.Dispose();
        }

        public void RemoveComponent(Type type)
        {
            if (IsDisposed)
            {
                return;
            }

            Entity c = GetComponent(type);
            if (c == null)
            {
                return;
            }

            RemoveFromComponent(type, c);
            c.Dispose();
        }

        public virtual K GetComponent<K>() where K : Entity
        {
            if (components == null)
            {
                return null;
            }

            Entity component;
            if (!components.TryGetValue(typeof (K), out component))
            {
                return default;
            }

            return (K) component;
        }

        public virtual Entity GetComponent(Type type)
        {
            if (components == null)
            {
                return null;
            }

            Entity component;
            if (!components.TryGetValue(type, out component))
            {
                return null;
            }

            return component;
        }
    }
}