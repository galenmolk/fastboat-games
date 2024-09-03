namespace DC.FSM
{
    public abstract class EnemyBaseState : State
    {
        protected EnemyStateMachine enemyStateMachine;

        protected EnemyBaseState(EnemyStateMachine enemyStateMachine)
        {
            this.enemyStateMachine = enemyStateMachine;
        }
    }
}
