using UnityEditor;
using UnityEngine;

namespace DC.AggroTriggers
{
    public class BoxAggroTrigger : AggroTrigger
    {
        public CircleCollider2D trigger;

        private void OnValidate()
        {
            if (!trigger)
            {
                trigger = GetComponent<CircleCollider2D>();
            }
        }

        private void OnDrawGizmos()
        {
            Handles.color = color;
            Handles.DrawWireDisc(transform.position, Vector3.back, trigger.radius);
        }
    }
}