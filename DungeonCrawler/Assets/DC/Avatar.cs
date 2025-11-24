using UnityEngine;

namespace DC
{
    public class Avatar : MonoBehaviour
    {
        private Attacker attacker;
        private Vector2 moveDirection;

        private float lastAttackTime;
        
        private void Start()
        {
            attacker = GetComponent<Attacker>();
        }

        private void Update()
        {
            Attack();
        }

        private void Attack()
        {
            var time = Time.time;
            if (Input.GetKey(KeyCode.Space) && time > lastAttackTime + attacker.attackDelay)
            {
                lastAttackTime = time;
                Debug.Log("Attack");
                attacker.Attack();
            }
        }
    }
}
