using System;
using UnityEngine;

namespace DC
{
    public class Coin : MonoBehaviour
    {
        public static event Action OnCoinPickedUp;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.IsPlayer())
            {
                OnCoinPickedUp?.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}
