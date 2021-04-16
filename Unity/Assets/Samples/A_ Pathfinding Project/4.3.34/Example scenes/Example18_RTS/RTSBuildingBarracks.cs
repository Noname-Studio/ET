using UnityEngine;
using System.Collections.Generic;

namespace Pathfinding.Examples.RTS
{
    [HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_examples_1_1_r_t_s_1_1_r_t_s_building_barracks.php")]
    public class RTSBuildingBarracks: MonoBehaviour
    {
        [System.Serializable]
        public class UnitItem
        {
            public GameObject prefab;
            public int cost;
            public float buildingTime;
            public RTSUI.MenuItem menuItem;
        }

        public UnitItem[] items;
        public Transform spawnPoint;
        public Transform rallyPoint;
        public int maxQueueSize = 4;
        private RTSUnit unit;
        private RTSUI.Menu menu;

        private float queueStartTime = 0;

        [System.NonSerialized]
        public List<UnitItem> queue = new List<UnitItem>();

        public float queueProgressFraction
        {
            get
            {
                if (queue.Count == 0)
                {
                    return 0;
                }

                return (Time.time - queueStartTime) / queue[0].buildingTime;
            }
        }

        private void Awake()
        {
            unit = GetComponent<RTSUnit>();

            unit.onMakeActiveUnit += (bool active) =>
            {
                if (active)
                {
                    menu = RTSUI.active.ShowMenu();
                    for (int i = 0; i < items.Length; i++)
                    {
                        var item = items[i];
                        menu.AddItem(item.menuItem, () =>
                        {
                            if (queue.Count >= maxQueueSize)
                            {
                                return;
                            }

                            if (RTSManager.instance.GetPlayer(1).resources.GetResource(RTSUnit.Type.ResourceCrystal) < item.cost)
                            {
                                RTSManager.instance.audio.Play(RTSUI.active.notEnoughResources);
                            }
                            else
                            {
                                RTSManager.instance.GetPlayer(1).resources.AddResource(RTSUnit.Type.ResourceCrystal, -item.cost);
                                AddToQueue(item);
                            }
                        });
                    }
                }
                else if (menu != null)
                {
                    menu.Hide();
                }
            };
        }

        private void AddToQueue(UnitItem item)
        {
            queue.Add(item);
            if (queue.Count == 1)
            {
                queueStartTime = Time.time;
            }
        }

        private void Spawn(UnitItem item)
        {
            var go = Instantiate(item.prefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
            var spawned = go.GetComponent<RTSUnit>();

            spawned.team = unit.team;
            spawned.SetDestination(rallyPoint.position, MovementMode.AttackMove);
        }

        private void Update()
        {
            if (queue.Count > 0 && Time.time - queueStartTime >= queue[0].buildingTime)
            {
                Spawn(queue[0]);
                queue.RemoveAt(0);
                queueStartTime = Time.time;
            }
        }
    }
}