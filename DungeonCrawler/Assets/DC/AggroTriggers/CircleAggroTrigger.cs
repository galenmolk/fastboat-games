using UnityEditor;
using UnityEngine;

namespace DC.AggroTriggers
{
    public class CircleAggroTrigger : AggroTrigger
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
            Handles.DrawWireCube(trigger.bounds.center, trigger.bounds.size);
        }
    }
}
