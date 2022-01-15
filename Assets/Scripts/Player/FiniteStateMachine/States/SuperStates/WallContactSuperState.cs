using Player.FiniteStateMachine.States.Base;

namespace Player.FiniteStateMachine.States.SuperStates
{
    public class WallContactSuperState : BasePlayerState
    {
        public WallContactSuperState(PlayerController playerController, string parameterName) : base(playerController, parameterName)
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
            if (Checks.IsGrounded&& !WallGrab)
            {
                StateMachine.ChangeState(States.Idle);
            }
            if (!Checks.IsGrounded && !Checks.WallContact)
            {
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