using System.Collections;
using UnityEngine;

namespace DC
{
      public class Attacker : MonoBehaviour
      {
            public float attackDelay => weapon.attackDelay;
            public WeaponCollider weaponCollider;
            public Weapon weapon;
            private Coroutine weaponRoutine;

            private void OnEnable()
            {
                  weaponCollider.OnHit += OnHit;
            }

            private void OnDisable()
            {
                  weaponCollider.OnHit -= OnHit;
            }

            private void OnHit(IDamageable damageable)
            {
                  damageable.TakeDamage(weapon.damage);
            }

            public void Attack()
            {
                  if (weaponRoutine != null)
                  {
                        StopCoroutine(weaponRoutine);
                  }

                  weaponRoutine = StartCoroutine(WeaponRoutine());
            }

            private IEnumerator WeaponRoutine()
            {
                  weaponCollider.SetIsEnabled(true);
                  yield return new WaitForSeconds(weapon.attackDuration);
                  weaponCollider.SetIsEnabled(false);
            }
      }
}
