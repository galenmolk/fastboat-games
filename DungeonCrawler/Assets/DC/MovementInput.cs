using UnityEngine;

namespace DC
{
    public class MovementInput : MonoBehaviour
    {
        public Rigidbody2D rb;

        [SerializeField] private float decelerationMagnitudeThreshold = 1.5f;
        [SerializeField] private float moveSpeed = 6.5f;
        [SerializeField] private float acceleration = 50f;
        [SerializeField] private float deceleration = 30f;
        
        private Vector2 moveDirection;
        private Vector2 currentVelocity;

        public bool isMoving => currentVelocity.sqrMagnitude > 0f;
        public bool isMovingUp => currentVelocity.y > 0f && Mathf.Abs(currentVelocity.y) > Mathf.Abs(currentVelocity.x);
        public bool isMovingDown => currentVelocity.y < 0f && Mathf.Abs(currentVelocity.y) > Mathf.Abs(currentVelocity.x);
        public bool isMovingRight => currentVelocity.x > 0f && Mathf.Abs(currentVelocity.x) > Mathf.Abs(currentVelocity.y);
        public bool isMovingLeft => currentVelocity.x < 0f && Mathf.Abs(currentVelocity.x) > Mathf.Abs(currentVelocity.y);
        
        private void Update()
        {
            Move();
        }
        
        private void Move()
        {
            // Get input from arrow keys
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");
            moveDirection = new Vector2(inputX, inputY).normalized;

            // Smoothly change velocity based on input and acceleration/deceleration
            if (moveDirection.magnitude > 0)
            {
                currentVelocity = Vector2.MoveTowards(currentVelocity, moveDirection * moveSpeed, acceleration * Time.deltaTime);
            }
            else
            {
                currentVelocity = Vector2.MoveTowards(currentVelocity, Vector2.zero, deceleration * Time.deltaTime);
           
                if (currentVelocity.magnitude < decelerationMagnitudeThreshold)
                {
                    currentVelocity = Vector2.zero;
                }
            }

            // Move the transform based on the current velocity
            rb.linearVelocity = currentVelocity;
        }
    }
}
