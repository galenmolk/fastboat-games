namespace DC.FSM
{
    public class EnemyBattleState : EnemyBaseState
    {
        protected override string Name => "Battle";

        
        public EnemyBattleState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
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
