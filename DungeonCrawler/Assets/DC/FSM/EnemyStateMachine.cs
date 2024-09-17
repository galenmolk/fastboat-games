using System;
using DC.Enemies;

namespace DC.FSM
{
    public class EnemyStateMachine : UnitStateMachine
    {
        public PatrolPath patrolPath;

        private void Start()
        {
            if (patrolPath)
            {
                ChangeState(new EnemyPatrolState(this, patrolPath));
            }
        }
    }
}
