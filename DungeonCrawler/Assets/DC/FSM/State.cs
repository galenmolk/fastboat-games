namespace DC.FSM
{
    public abstract class State
    {
        protected FiniteStateMachine stateMachine;
        
        public abstract void Enter(FiniteStateMachine stateMachine);
        public abstract void Tick();
        public abstract void Exit();
    }
}
