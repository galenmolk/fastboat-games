namespace DC.FSM
{
    public abstract class State
    {
        public abstract void Enter();
        public abstract void Tick();
        public abstract void Exit();
        
        protected abstract string Name { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}
