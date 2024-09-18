using DC.Enemies;

namespace DC.FSM
{
    public class EnemyStateMachine : UnitStateMachine
    {
        public PatrolPath patrolPath;
        
        protected override State GetDefaultState()
        {
            if (patrolPath)
            {
                return new EnemyPatrolState(this, patrolPath);
            }
            else
            {
                return new EnemyIdleState(this);
            }
        }
    }
}
