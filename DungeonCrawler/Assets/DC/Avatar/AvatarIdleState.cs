namespace DC
{
    public class AvatarIdleState : AvatarBaseState
    {
        protected override string Name => "Idle";
        
        public AvatarIdleState(AvatarStateMachine fsm) : base(fsm)
        {
        }

        public override void Enter()
        {
            fsm.animator.SetTrigger("Idle");
        }

        public override void Tick()
        {
            if (fsm.movementInput.isMoving)
            {
                fsm.ChangeState(new AvatarMoveState(fsm));
            }
        }

        public override void Exit()
        {
        }
    }
}
