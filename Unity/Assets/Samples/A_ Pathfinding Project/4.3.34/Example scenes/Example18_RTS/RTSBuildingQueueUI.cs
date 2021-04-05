using UnityEngine;
using UnityEngine.UI;

namespace Pathfinding.Examples.RTS
{
    [HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_examples_1_1_r_t_s_1_1_r_t_s_building_queue_u_i.php")]
    public class RTSBuildingQueueUI: VersionedMonoBehaviour
    {
        private RTSBuildingBarracks building;
        public GameObject prefab;
        public Vector3 worldOffset;
        public Vector2 screenOffset;
        private UIItem item;

        private class UIItem: RTSWorldSpaceUI.Item
        {
            private QueItem[] queItems;
            private RTSBuildingQueueUI parent;

            public UIItem(Transform tracking, RTSBuildingQueueUI parent): base(tracking)
            {
                this.parent = parent;
            }

            private struct QueItem
            {
                public GameObject root;
                public Image icon;
                public Image progress;

                public QueItem(Transform root)
                {
                    this.root = root.gameObject;
                    icon = root.Find("Mask/Image").GetComponent<Image>();
                    var p = root.Find("QueProgress");
                    progress = p != null? p.GetComponent<Image>() : null;
                }
            }

            public override void SetUIRoot(GameObject root)
            {
                base.SetUIRoot(root);
                queItems = new QueItem[4];
                queItems[0] = new QueItem(root.transform.Find("Que0"));
                queItems[1] = new QueItem(root.transform.Find("Que/Que1"));
                queItems[2] = new QueItem(root.transform.Find("Que/Que2"));
                queItems[3] = new QueItem(root.transform.Find("Que/Que3"));
            }

            public override void Update(Camera cam)
            {
                base.Update(cam);
                for (int i = 0; i < queItems.Length; i++)
                {
                    if (i >= parent.building.queue.Count)
                    {
                        queItems[i].root.SetActive(false);
                    }
                    else
                    {
                        queItems[i].root.SetActive(true);
                        if (i == 0)
                        {
                            queItems[i].progress.fillAmount = parent.building.queueProgressFraction;
                        }

                        queItems[i].icon.sprite = null; //parent.building.queue[i].prefab.GetComponent;
                    }
                }
            }
        }

        protected override void Awake()
        {
            base.Awake();
            building = GetComponent<RTSBuildingBarracks>();
        }

        private void Start()
        {
            item = new UIItem(transform, this);
            RTSUI.active.worldSpaceUI.Add(item, prefab);
        }

#if UNITY_EDITOR
        private void Update()
        {
            item.worldOffset = worldOffset;
            item.screenOffset = screenOffset;
        }
#endif
    }
}