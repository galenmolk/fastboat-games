using UnityEngine;
using UnityEngine.Events;

namespace DC.AggroTriggers
{
    public abstract class AggroTrigger : MonoBehaviour
    {
        public Color color = Color.red;
        public UnityEvent<Transform> OnAggro;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.IsPlayer())
            {
                OnAggro?.Invoke(other.transform);
            }
        }
    }
}
