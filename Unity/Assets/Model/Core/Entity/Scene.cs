namespace ET
{
    public sealed class Scene: Entity
    {
        public int Zone { get; }

        public SceneType SceneType { get; }

        public string Name { get; set; }

        public Scene(long id, int zone, SceneType sceneType, string name)
        {
            Id = id;
            InstanceId = id;
            Zone = zone;
            SceneType = sceneType;
            Name = name;
            IsCreate = true;

            Log.Info($"scene create: {SceneType} {Name} {Id} {InstanceId} {Zone}");
        }

        public Scene(long id, long instanceId, int zone, SceneType sceneType, string name)
        {
            Id = id;
            InstanceId = instanceId;
            Zone = zone;
            SceneType = sceneType;
            Name = name;
            IsCreate = true;

            Log.Info($"scene create: {SceneType} {Name} {Id} {InstanceId} {Zone}");
        }

        public override void Dispose()
        {
            base.Dispose();

            Log.Info($"scene dispose: {SceneType} {Name} {Id} {InstanceId} {Zone}");
        }

        public Scene Get(long id)
        {
            if (Children == null)
            {
                return null;
            }

            if (!Children.TryGetValue(id, out Entity entity))
            {
                return null;
            }

            return entity as Scene;
        }

        public new Entity Domain
        {
            get => domain;
            set => domain = value;
        }

        public new Entity Parent
        {
            get
            {
                return parent;
            }
            set
            {
                if (value == null)
                {
                    parent = this;
                    return;
                }

                parent = value;
                parent.Children.Add(Id, this);
#if UNITY_EDITOR && VIEWGO
                if (this.ViewGO != null)
                {
                    this.ViewGO.transform.SetParent(this.parent.ViewGO.transform, false);
                }
#endif
            }
        }
    }

    public static class SceneEx
    {
        public static int DomainZone(this Entity entity)
        {
            return ((Scene) entity.Domain)?.Zone ?? 0;
        }

        public static Scene DomainScene(this Entity entity)
        {
            return (Scene) entity.Domain;
        }
    }
}