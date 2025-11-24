using UnityEngine;

namespace DC
{
    public class AvatarMoveState : AvatarBaseState
    {
        protected override string Name => "Move";
        
        public AvatarMoveState(AvatarStateMachine fsm) : base(fsm)
        {
        }

        public override void Enter()
        {
        }

        public override void Tick()
        {
            if (fsm.movementInput.isMovingUp)
            {
                Debug.Log($"Moving Up");
            }
            else if (fsm.movementInput.isMovingDown)
            {
                Debug.Log($"Moving Down");

            }
            else if (fsm.movementInput.isMovingRight)
            {
                Debug.Log($"Moving Right");

            }
            else if (fsm.movementInput.isMovingLeft)
            {
                Debug.Log($"Moving Left");
            }
            else
            {
                fsm.ChangeState(new AvatarIdleState(fsm));
            }
        }

        public override void Exit()
        {
        }
    }
}
