using UnityEngine;

namespace Pathfinding
{
    using Util;

    /// <summary>Helper for <see cref="Pathfinding.Examples.LocalSpaceRichAI"/></summary>
    [HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_local_space_graph.php")]
    public class LocalSpaceGraph: VersionedMonoBehaviour
    {
        private Matrix4x4 originalMatrix;
        private MutableGraphTransform graphTransform = new MutableGraphTransform(Matrix4x4.identity);
        public GraphTransform transformation => graphTransform;

        private void Start()
        {
            originalMatrix = transform.worldToLocalMatrix;
            transform.hasChanged = true;
            Refresh();
        }

        public void Refresh()
        {
            // Avoid updating the GraphTransform if the object has not moved
            if (transform.hasChanged)
            {
                graphTransform.SetMatrix(transform.localToWorldMatrix * originalMatrix);
                transform.hasChanged = false;
            }
        }
    }
}