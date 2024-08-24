using UnityEditor;
using UnityEngine;

namespace DC.Enemies
{
    public class PatrolPath : MonoBehaviour
    {
        [Range(1f, 10f)] public float screenSpaceSize = 5f;
        public Color color = Color.white;

        private void OnValidate()
        {
            Transform[] children = GetComponentsInChildren<Transform>();
            foreach (var c in children)
            {
                if (!c.GetComponent<PatrolPathNode>())
                {
                    c.gameObject.AddComponent<PatrolPathNode>().patrolPath = this;
                }
            }
        }

        public void OnDrawGizmosSelected()
        {
            for (int i = 0; i < transform.childCount - 1; i++)
            {
                var c1 = transform.GetChild(i);
                var c2 = transform.GetChild(i + 1);
                Handles.color = color;
                Handles.DrawDottedLine(c1.position, c2.position, screenSpaceSize);
            }
        }
    }
}
