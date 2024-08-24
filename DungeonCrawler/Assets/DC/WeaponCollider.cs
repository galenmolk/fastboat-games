using System;
using UnityEngine;

namespace DC
{
    [RequireComponent(typeof(Collider2D))]
    public class WeaponCollider : MonoBehaviour
    {
        public event Action<IDamageable> OnHit;

        private Collider2D col;

        public GameObject weaponGraphics;

        public void SetIsEnabled(bool isEnabled)
        {
            col.enabled = isEnabled;
            weaponGraphics.SetActive(isEnabled);
        }

        private void Awake()
        {
            col = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log($"triggered {other.gameObject.name}");
            if (other.gameObject.TryGetComponent(out IDamageable damageable))
            {
                OnHit?.Invoke(damageable);
            }
        }
    }
}
