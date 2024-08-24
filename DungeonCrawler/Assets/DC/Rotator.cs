using System;
using UnityEngine;

namespace DC
{
    public class Rotator : MonoBehaviour
    {
        public Rigidbody2D rb;
        public Transform graphicsTransform;
        
        private void Update()
        {
            var velocity = rb.velocity;
            if (velocity.magnitude > 0f)
            {
                var angle = (float)Math.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
                graphicsTransform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
        }
    }
}
