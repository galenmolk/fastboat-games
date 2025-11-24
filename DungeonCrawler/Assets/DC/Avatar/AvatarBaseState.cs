using DC.FSM;

namespace DC
{
    public abstract class AvatarBaseState : State
    {
        protected AvatarStateMachine fsm;

        protected AvatarBaseState(AvatarStateMachine fsm)
        {
            this.fsm = fsm;
        }
    }
}
