using Cysharp.Threading.Tasks;
using Panthea.Asset;
using UnityEngine;

namespace Kitchen
{
    /// <summary>
    /// 玩家手上的托盘
    /// </summary>
    public class PlayerTray
    {
        private enum ItemType
        {
            None,
            Food,
            Ingedient
        }

        private class Display
        {
            public UnityObject Model;
            public Material Material;
            public Texture Texture;

            public Display(UnityObject display, UnityObject parent, int render)
            {
                Model = display;
                Model.Parent = parent;
                Model.LocalScale = Vector3.one;
                var renderer = Model.GetComponent<MeshRenderer>();
                Object.Destroy(Model.GetComponent<Collider>());
                Material = new Material(Shader.Find("URP/BetterTransparent"));
                Material.renderQueue = render;
                renderer.sharedMaterial = Material;
                Model.Active = false;
            }

            public void SetActive(bool active)
            {
                Model.Active = active;
            }

            public void SetTexture(Texture tex)
            {
                Material.SetTexture(ShaderHelper.MainTexture, tex);
                Texture = tex;
            }

            public void Dispose()
            {
                Object.Destroy(Material);
            }
        }

        public string Item { get; private set; }
        private ItemType mType;
        private Display Tray;

        private Display Food;

        //我们需要一个在手上得基点
        private Transform CameraTransform;
        private UnityObject mPivot;

        public PlayerTray(UnityObject pivot)
        {
            mPivot = pivot;
            CameraTransform = KitchenRoot.Inst.MainCamera.transform;
            Tray = new Display(new UnityObject(GameObject.CreatePrimitive(PrimitiveType.Quad)), pivot, 3000);
            Food = new Display(new UnityObject(GameObject.CreatePrimitive(PrimitiveType.Quad)), pivot, 3001);
        }

        public async UniTaskVoid Hold(string id)
        {
            Item = id;
            mType = id.StartsWith("F_")? ItemType.Food : ItemType.Ingedient;
            Tray.SetActive(true);
            Food.SetActive(true);
            var plate = AssetsKit.Inst.Load<Texture>("Image/Food/plate1_1").AsTask();
            Tray.SetTexture(plate.Result);
            if (mType == ItemType.Ingedient)
            {
                var property = KitchenDataHelper.LoadFood(id);
                var food = AssetsKit.Inst.Load<Texture>(property.CurrentLevel.Texture).AsTask();
                await food;
                Food.SetTexture(food.Result);
            }
            else if (mType == ItemType.Food)
            {
                var property = KitchenDataHelper.LoadFood(id);
                var food = AssetsKit.Inst.Load<Texture>(property.CurrentLevel.Texture).AsTask();
                await food;
                Food.SetTexture(food.Result);
            }
        }

        public string Take()
        {
            var item = Item;
            Item = null;
            mType = ItemType.None;
            Tray.SetActive(false);
            Food.SetActive(false);
            return item;
        }

        public void Update()
        {
            Tray.Model.EulerAngles = new Vector3(30, 135, 0);
            Food.Model.EulerAngles = new Vector3(30, 135, 0);
            var pt = mPivot.TransformPoint(Vector3.zero);
            /*var heading = CameraTransform.position - mPivot.Position;
            var distance = heading.magnitude;
            var direction = heading / distance;
            GameEntry.inst.Vec = direction;
            var position = direction * GameEntry.inst.X + GameEntry.inst.XXX;*/
            Tray.Model.Position = pt;
            Food.Model.Position = pt;
        }

        public void Dispose()
        {
            Tray.Dispose();
            Food.Dispose();
        }
    }
}