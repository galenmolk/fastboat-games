namespace DC.FSM
{
    public abstract class EnemyBaseState : State
    {
        protected EnemyStateMachine fsm;

        protected EnemyBaseState(EnemyStateMachine fsm)
        {
            this.fsm = fsm;
        }
    }
}
