using UnityEngine;
using UnityEngine.UI;

namespace DC
{
    public class Health : MonoBehaviour, IDamageable
    {
        public int startingHp = 3;
        public Image healthBar;
        private int currentHp;

        private void Start()
        {
            currentHp = startingHp;
        }

        public void AddHealth(int amount)
        {
            currentHp = Mathf.Min(currentHp + amount, startingHp);
            UpdateBar();
        }
        
        public void TakeDamage(int damage)
        {
            currentHp -= damage;

            UpdateBar();
        
            if (currentHp <= 0)
            {
                Debug.Log($"{gameObject.name} Died");
                Destroy(gameObject);
            }
        }

        private void UpdateBar()
        {
            healthBar.fillAmount = currentHp / (float)startingHp;
        }
    }
}
