using DC.Enemies;

namespace DC.FSM
{
    public class EnemyPatrolState : EnemyBaseState
    {
        protected override string Name => "Patrol";

        private PatrolPath path;
        
        public EnemyPatrolState(
            EnemyStateMachine enemyStateMachine,
            PatrolPath path
            ) : base(enemyStateMachine)
        {
            this.path = path;
        }
        
        public override void Enter()
        {
        }

        public override void Tick()
        {
        }

        public override void Exit()
        {
        }
    }
}
