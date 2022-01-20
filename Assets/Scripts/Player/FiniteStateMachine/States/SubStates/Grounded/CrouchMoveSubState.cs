using Player.FiniteStateMachine.States.SuperStates;

namespace Player.FiniteStateMachine.States.SubStates.Grounded
{
    public class CrouchMoveSubState : GroundedSuperState
    {
        public CrouchMoveSubState(PlayerController playerController, string parameterName) : base(playerController, parameterName)
        {
        }

        public override void Enter()
        {
            PlayerController.topCollider.enabled = false;
            base.Enter();
        }

        public override void Exit()
        {
            PlayerController.topCollider.enabled=true;
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (IsStateComplete) return;
            if (InputX == 0 && InputY == 0)
            {
                StateMachine.ChangeState(States.Idle);
            }
            else if (InputX != 0 && InputY < 0)
            {
                StateMachine.ChangeState(PlayerController.States.CrouchMove);
            }
            else if (InputX == 0 && InputY < 0)
            {
                StateMachine.ChangeState(PlayerController.States.CrouchIdle);
            }
            else if (InputX != 0 && InputY > 0)
            {
                StateMachine.ChangeState(PlayerController.States.Move);
            }
            if (InputX != 0 && Checks.IsGrounded)
            {
                Movement.Flip(InputX);
                Movement.SetVelocity_X(Data.moveSpeed * InputX);
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