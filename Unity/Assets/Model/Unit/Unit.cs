using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace ET
{
    public sealed class Unit: Entity
    {
        // 先放这里，去掉ViewGO，后面挪到显示层
        public GameObject GameObject;

        public int ConfigId;

        public UnitConfig Config => UnitConfigCategory.Instance.Get(ConfigId);

        public Vector3 Position
        {
            get => GameObject.transform.position;
            set => GameObject.transform.position = value;
        }

        public Quaternion Rotation
        {
            get => GameObject.transform.rotation;
            set => GameObject.transform.rotation = value;
        }
    }
}