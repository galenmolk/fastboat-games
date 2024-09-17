namespace DC.FSM
{
    public class EnemyIdleState : EnemyBaseState
    {
        protected override string Name => "Idle";

        public EnemyIdleState(EnemyStateMachine fsm) : base(fsm)
        {
        }
        
        public override void Enter()
        {
        }

        public override void Tick() { }

        public override void Exit() { }
    }
}
