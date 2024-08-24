using UnityEngine;

namespace DC
{
    public class Avatar : MonoBehaviour
    {
        [SerializeField] private Rect rect;
    
        private void OnGUI()
        {
            //GUI.Label(rect, new GUIContent(
           //     $"currentVelocity.mag: {currentVelocity.magnitude}"));
        }

        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float acceleration = 10f;
        [SerializeField] private float deceleration = 10f;
        [SerializeField] private float decelerationMagnitudeThreshold = 0.5f;

        private Vector2 currentVelocity;

        private Rigidbody2D rb;
        private Attacker attacker;
        private Vector2 moveDirection;

        private float lastAttackTime;
        
        private void Start()
        {
            attacker = GetComponent<Attacker>();
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
            Attack();
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
            rb.velocity = currentVelocity;
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
