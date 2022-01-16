using Player.FiniteStateMachine.States.SuperStates;

namespace Player.FiniteStateMachine.States.SubStates.WallContact
{
    public class WallGrabSubState : WallContactSuperState
    {
        private float _rigidbodyGravity;
        public WallGrabSubState(PlayerController playerController, string parameterName) : base(playerController, parameterName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _rigidbodyGravity = PlayerController.Rigidbody.gravityScale;
            PlayerController.Rigidbody.gravityScale = 0;
            Movement.SetVelocity_Y(0f);
        }

        public override void Exit()
        {
            base.Exit();
            PlayerController.Rigidbody.gravityScale = _rigidbodyGravity;

        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (InputY > 0)
            {
                StateMachine.ChangeState(States.WallClimb);
            }
            else if(InputY < 0 && !Checks.IsGrounded)
            {
                StateMachine.ChangeState(States.WallSlide);
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