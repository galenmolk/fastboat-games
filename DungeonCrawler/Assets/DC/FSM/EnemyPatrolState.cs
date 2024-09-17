using DC.Enemies;
using UnityEngine;

namespace DC.FSM
{
    public class EnemyPatrolState : EnemyBaseState
    {
        protected override string Name => "Patrol";

        private readonly PatrolPath path;
        private int targetNodeIndex;
        private float timeAtNode;
        private Vector2 currentVelocity = Vector2.zero;
        private bool isMovingForward = true;

        private PatrolPathNode getTargetNode => path[targetNodeIndex];
        
        public EnemyPatrolState(EnemyStateMachine fsm, PatrolPath path) : base(fsm)
        {
            this.path = path;
        }
        
        public override void Enter()
        {
            PatrolPathNode startNode = path.startNode;
            fsm.SetPosition(startNode.position);
            targetNodeIndex = 1;
        }

        public override void Tick()
        {
            var currentPosition = fsm.position;
            var targetNode = getTargetNode;
            var targetPosition = targetNode.position;
            var distance = Vector2.Distance(currentPosition, targetPosition);

            if (distance <= fsm.slowingDistance)
            {
                currentVelocity = Vector2.MoveTowards(currentVelocity, Vector2.zero, fsm.deceleration * Time.deltaTime);
            }
            else
            {
                var direction = (targetPosition - fsm.position).normalized;
                currentVelocity = Vector2.MoveTowards(currentVelocity, direction * fsm.speed, fsm.acceleration * Time.deltaTime);
            }
        
            if (currentVelocity.magnitude <= fsm.stoppingSpeedThreshold)
            {
                timeAtNode += Time.deltaTime;

                if (timeAtNode > targetNode.pauseDuration)
                {
                    timeAtNode = 0f;
                    Progress();
                }
            }
        
            fsm.SetVelocity(currentVelocity);
        }
        
        private void Progress()
        {
            if (isMovingForward)
            {
                if (targetNodeIndex < path.NodeCount - 1)
                {
                    targetNodeIndex++;
                }
                else
                {
                    isMovingForward = false;
                    targetNodeIndex--;
                }
            }
            else
            {
                if (targetNodeIndex > 0)
                {
                    targetNodeIndex--;
                }
                else
                {
                    isMovingForward = true;
                    targetNodeIndex++;
                }
            }
        }

        public override void Exit()
        {
        }
    }
}
