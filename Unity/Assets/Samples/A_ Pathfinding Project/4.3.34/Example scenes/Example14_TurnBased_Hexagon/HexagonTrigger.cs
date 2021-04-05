using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Pathfinding.Examples
{
    /// <summary>Helper script in the example scene 'Turn Based'</summary>
    [RequireComponent(typeof (Animator))]
    [HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_examples_1_1_hexagon_trigger.php")]
    public class HexagonTrigger: MonoBehaviour
    {
        public Button button;
        private Animator anim;
        private bool visible;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            button.interactable = false;
        }

        private void OnTriggerEnter(Collider coll)
        {
            var unit = coll.GetComponentInParent<TurnBasedAI>();
            var node = AstarPath.active.GetNearest(transform.position).node;

            // Check if it was a unit and the unit was headed for this node
            if (unit != null && unit.targetNode == node)
            {
                button.interactable = true;
                visible = true;
                anim.CrossFade("show", 0.1f);
            }
        }

        private void OnTriggerExit(Collider coll)
        {
            if (coll.GetComponentInParent<TurnBasedAI>() != null && visible)
            {
                button.interactable = false;
                anim.CrossFade("hide", 0.1f);
            }
        }
    }
}