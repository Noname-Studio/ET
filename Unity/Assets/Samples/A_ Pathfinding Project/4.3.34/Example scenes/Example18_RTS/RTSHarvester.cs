using UnityEngine;
using System.Collections;
using System.Linq;
using Pathfinding;
using Pathfinding.Examples.RTS;

namespace Pathfinding.Examples.RTS
{
    [HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_examples_1_1_r_t_s_1_1_r_t_s_harvester.php")]
    public class RTSHarvester: MonoBehaviour
    {
        private RTSUnit unit;
        private Animator animator;

        private void Awake()
        {
            unit = GetComponent<RTSUnit>();
            animator = GetComponent<Animator>();

            ctx = new BTContext { animator = animator, transform = transform, unit = unit };
        }

        private BTNode behave;

        private BTContext ctx;

        // Use this for initialization
        private void Start()
        {
            StartCoroutine(StateMachine());
            behave = Behaviors.HarvestBehavior();
        }

        private RTSHarvestableResource FindFreeResource()
        {
            /*var resources = FindObjectsOfType<RTSHarvestableResource>().Where(c => c.reservedBy == null).ToArray();
            RTSHarvestableResource closest = null;
            var dist = float.PositiveInfinity;
            var point = transform.position;
            for (int i = 0; i < resources.Length; i++) {
                var d = (resources[i].transform.position - point).sqrMagnitude;
                if (d < dist) {
                    dist = d;
                    closest = resources[i];
                }
            }
            return closest;*/
            return null;
        }

        private void OnDestroy()
        {
            behave.Terminate(ctx);
        }

        private IEnumerator StateMachine()
        {
            yield break;
        }

        // Update is called once per frame
        private void Update()
        {
            behave.Tick(ctx);
        }
    }
}