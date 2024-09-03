namespace DC.FSM
{
    public class EnemyChaseState : EnemyBaseState
    {
        protected override string Name => "Chase";
        
        public EnemyChaseState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
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
