using UnityEngine;

namespace Kitchen
{
    public class InputHandler
    {
        public class CameraInfo
        {
            public Camera Main;
            public Transform Transform;
    
            public CameraInfo(Camera main)
            {
                Main = main;
                Transform = main.transform;
            }
        }
        
        private UnityBehaviour mBehaviour;
        private QueueEventsKit mActionManager;
        private CameraInfo mCamera;
        private PlayerController mPlayer;
        public InputHandler()
        {
            mBehaviour = UnityLifeCycleKit.Inst;
            mActionManager = QueueEventsKit.Inst;
            mCamera = new CameraInfo(Camera.main);
            mBehaviour.AddUpdate(Update);
        }
    
        public void Init(PlayerController controller)
        {
            mPlayer = controller;
        }
        
        private float Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 inputPosition = Input.mousePosition;
                if (Physics.Raycast(mCamera.Main.ScreenPointToRay(inputPosition),out RaycastHit hit))
                {
                    DoJob(hit);
                }
            }
            return 0;
        }
    
        private void DoJob(RaycastHit hit)
        {
            var transform = hit.transform;
            if (transform == null)
                return;
            
            var cookware = KitchenRoot.Inst.Scene.GetCookware(transform);
            if (cookware != null)
            {
                Log.Print("Click Cookware");
                ClickCookware action = new ClickCookware(mPlayer, cookware);
                mActionManager.AddToBottom(action);
                return;
            }

            var ingredient = KitchenRoot.Inst.Scene.GetIngredient(transform);
            if (ingredient != null)
            {
                Log.Print("Click Ingredient");
                ClickIngredient action = new ClickIngredient(mPlayer, ingredient);
                mActionManager.AddToBottom(action);
                return;
            }

            var spot = KitchenRoot.Inst.SpotProvider.GetSpot(hit.transform.position);
            if (spot != null)
            {
                Log.Print("Click Spot");
                ClickSpot action = new ClickSpot(mPlayer,spot);
                mActionManager.AddToBottom(action);
                return;
            }
        }
    }
}
