using Player.FiniteStateMachine.States.Base;

namespace Player.FiniteStateMachine.States.SuperStates
{
    public class GroundedSuperState:BasePlayerState
    {
        public GroundedSuperState(PlayerController playerController, string parameterName) : base(playerController, parameterName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            States.Jump.ResetJumps();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (JumpInput && Checks.IsGrounded && States.Jump.CanJump)
            {
                Input.UseJumpInput();
                StateMachine.ChangeState(States.Jump);
            }
            if (!Checks.IsGrounded)
            {
                States.Airborne.SetCoyoteTime();
                StateMachine.ChangeState(States.Airborne);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        protected override void DoChecks()
        {
            base.DoChecks();
        }
    }
}