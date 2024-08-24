using System;
using UnityEngine;

namespace DC.Enemies
{
    public class ProximityAttack : MonoBehaviour
    {
        public Attacker attacker;
        public float proximity = 2f;
        public Transform graphicsTransform;
        
        private float lastAttackTime;
        private bool isInProximity;
        private Transform avatarTransform;
        
        private void Start()
        {
            avatarTransform = GameObject.FindWithTag("Player").transform;
        }

        private void Update()
        {
            if (!avatarTransform)
            {
                return;
            }
            var distance = Vector2.Distance(transform.position, avatarTransform.position);

            if (distance > proximity)
            {
                return;
            }

            var direction = (avatarTransform.position - graphicsTransform.position).normalized;
            var angle = (float)Math.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            graphicsTransform.rotation = Quaternion.Euler(0f, 0f, angle);

            var time = Time.time;
            if (time > lastAttackTime + attacker.attackDelay)
            {
                lastAttackTime = time;
                attacker.Attack();
            }
        } 
    }
}
