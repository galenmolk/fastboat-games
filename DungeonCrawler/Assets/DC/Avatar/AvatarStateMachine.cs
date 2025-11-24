using DC.FSM;
using UnityEngine;

namespace DC
{
    public class AvatarStateMachine : UnitStateMachine
    {
        public MovementInput movementInput;
        public Animator animator;

        protected override State GetDefaultState()
        {
            return new AvatarIdleState(this);
        }
    }
}
