using UnityEngine;

namespace DC
{
    public class AvatarAnimator : MonoBehaviour
    {
        public Animator animator;
        public Rigidbody2D rb;
        public float threshold = 0.01f;
        
        private bool isIdle;
        
        private void Update()
        {
            var currVelocity = rb.linearVelocity;
            if (Mathf.Abs(currVelocity.magnitude) < threshold)
            {
                if (!isIdle)
                {
                    isIdle = true;
                    animator.SetTrigger("Idle");
                }
                
                return;
            }

            isIdle = false;
            animator.SetFloat("xVelocity", currVelocity.x);
            animator.SetFloat("yVelocity", currVelocity.y);
        }
    }
}