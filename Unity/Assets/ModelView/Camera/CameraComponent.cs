using UnityEngine;

namespace ET
{
    public class CameraComponentAwakeSystem: AwakeSystem<CameraComponent>
    {
        public override void Awake(CameraComponent self)
        {
            self.Awake();
        }
    }

    public class CameraComponentLateUpdateSystem: LateUpdateSystem<CameraComponent>
    {
        public override void LateUpdate(CameraComponent self)
        {
            self.LateUpdate();
        }
    }

    public class CameraComponent: Entity
    {
        // 战斗摄像机
        public Camera mainCamera;

        public Unit Unit;

        public Camera MainCamera => mainCamera;

        public void Awake()
        {
            mainCamera = Camera.main;
        }

        public void LateUpdate()
        {
            // 摄像机每帧更新位置
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            Vector3 cameraPos = mainCamera.transform.position;
            mainCamera.transform.position = new Vector3(Unit.Position.x, cameraPos.y, Unit.Position.z - 1);
        }
    }
}