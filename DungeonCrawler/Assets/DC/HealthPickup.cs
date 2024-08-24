using System;
using UnityEngine;

namespace DC
{
    public class HealthPickup : MonoBehaviour
    {
        public int amount;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.IsPlayer())
            {
                var health = other.gameObject.GetComponent<Health>();
                if (health)
                {
                    health.AddHealth(amount);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
