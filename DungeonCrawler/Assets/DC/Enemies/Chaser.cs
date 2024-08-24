using Pathfinding;
using UnityEngine;

namespace DC.Enemies
{
    [RequireComponent(typeof(Seeker))]
    public class Chaser : MonoBehaviour
    {
        public Transform target;
        public Rigidbody2D rb;
        public float acceleration = 30f;
        public float speed = 4f;
        public float endStoppingDistance = 1f;
        public float nodeStoppingDistance = 0.1f;
        public float updateFrequency = 1f;
        public float targetMovementThreshold = 0.1f;
        public Patroller patroller;
        
        private float lastUpdateTime;
        private bool isChasing;
        private Vector3 endNode;
        private Path currentPath;
        private int targetNodeIndex;
        private Vector3 nextNode;
        private Vector2 currentVelocity;
        private Seeker seeker;

        private void Start()
        {
            seeker = GetComponent<Seeker>();
            rb = GetComponent<Rigidbody2D>();
        }

        [ContextMenu("Chase")]
        public void Chase(Transform target)
        {
            if (patroller)
            {
                patroller.isPatrolling = false;
            }
            this.target = target;
            Debug.Log("Chase");
            seeker.CancelCurrentPathRequest();
            seeker.StartPath(transform.position, target.position, Callback);
        }

        private void Callback(Path path)
        {
            if (path.error)
            {
                Debug.LogError(path.errorLog);
                return;
            }
        
            currentPath = path;
            targetNodeIndex = 0;
            nextNode = currentPath.vectorPath[targetNodeIndex];
            endNode = currentPath.vectorPath[^1];
            isChasing = true;
        }

        private void Update()
        {
            if (!target)
            {
                return;
            }
            var time = Time.time;
            if (time > lastUpdateTime + updateFrequency)
            {
                lastUpdateTime = time;
                if (currentPath != null)
                {
                    if ((target.position - currentPath.vectorPath[^1]).magnitude > targetMovementThreshold)
                    {
                        Chase(target);
                    }
                }
            }
        
            if (isChasing && currentPath != null)
            {
                var currentPosition = transform.position;
                var direction = (nextNode - currentPosition).normalized;
                currentVelocity = Vector2.MoveTowards(currentVelocity, direction * speed, acceleration * Time.deltaTime);
                rb.velocity = currentVelocity;

                if (Vector2.Distance(currentPosition, endNode) <= endStoppingDistance)
                {
                    rb.velocity = Vector2.zero;
                    isChasing = false;
                    return;
                }

                if (Vector2.Distance(currentPosition, nextNode) <= nodeStoppingDistance)
                {
                    targetNodeIndex++;
                    nextNode = currentPath.vectorPath[targetNodeIndex];
                }
            }
        }
    }
}
