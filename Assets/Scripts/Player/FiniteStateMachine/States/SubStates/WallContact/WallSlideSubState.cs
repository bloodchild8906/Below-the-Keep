using Player.FiniteStateMachine.States.SuperStates;

namespace Player.FiniteStateMachine.States.SubStates.WallContact
{
    public class WallSlideSubState:WallContactSuperState
    {
        public WallSlideSubState(PlayerController playerController, string parameterName) : base(playerController, parameterName)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            Movement.SetVelocity_Y(-Data.wallSlideVelocity);
            if (Checks.IsGrounded && WallGrab)
                StateMachine.ChangeState(States.WallGrab);
            
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