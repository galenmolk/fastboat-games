using System.Collections.Generic;
using UnityEngine;

namespace DC.Enemies
{
    public class Patroller : MonoBehaviour
    {
        public PatrolPath patrolPath;
        
        private int targetPointIndex;
    
        public float speed = 4f;
        public float stoppingSpeedThreshold = 0.1f;
        public float slowingDistance = 1f;

        public float acceleration = 50f;
        public float deceleration = 30f;

        public bool isPatrolling = true;
        
        private bool isMovingForward = true;
        private List<PatrolPathNode> route;
        
        private PatrolPathNode targetPoint => route[targetPointIndex];
    
        private float timeAtPoint;
        private Vector2 currentVelocity = Vector2.zero;
        private Rigidbody2D rb;
    
        private void Start()
        {
            route = new List<PatrolPathNode>();
            foreach (Transform child in patrolPath.transform)
            {
                route.Add(child.GetComponent<PatrolPathNode>());
            }
            
            rb = GetComponent<Rigidbody2D>();
            transform.position = route[0].position;
            targetPointIndex = 1;
        }

        private void Update()
        {
            if (!isPatrolling)
            {
                return;
            }
            
            var currentPosition = transform.position;

            var distance = Vector2.Distance(currentPosition, targetPoint.position);
            if (distance <= slowingDistance)
            {
                currentVelocity = Vector2.MoveTowards(currentVelocity, Vector2.zero, deceleration * Time.deltaTime);
            }
            else
            {
                var direction = (targetPoint.position - (Vector2)transform.position).normalized;
                currentVelocity = Vector2.MoveTowards(currentVelocity, direction * speed, acceleration * Time.deltaTime);
            }
        
            if (currentVelocity.magnitude <= stoppingSpeedThreshold)
            {
                timeAtPoint += Time.deltaTime;

                if (timeAtPoint > targetPoint.pauseDuration)
                {
                    timeAtPoint = 0f;
                    Progress();
                }
            }
        
            rb.velocity = currentVelocity;
        }

        private void Progress()
        {
            if (isMovingForward)
            {
                if (targetPointIndex < route.Count - 1)
                {
                    targetPointIndex++;
                }
                else
                {
                    isMovingForward = false;
                    targetPointIndex--;
                }
            }
            else
            {
                if (targetPointIndex > 0)
                {
                    targetPointIndex--;
                }
                else
                {
                    isMovingForward = true;
                    targetPointIndex++;
                }
            }
        }
    }
}
