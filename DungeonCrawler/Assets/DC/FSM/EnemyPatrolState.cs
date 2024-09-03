namespace DC.FSM
{
    public class EnemyPatrolState : EnemyBaseState
    {
        protected override string Name => "Patrol";

        public EnemyPatrolState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
        {
            
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
