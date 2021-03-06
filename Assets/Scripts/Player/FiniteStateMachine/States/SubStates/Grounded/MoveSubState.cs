using Player.FiniteStateMachine.States.SuperStates;

namespace Player.FiniteStateMachine.States.SubStates.Grounded
{
    public class MoveSubState : GroundedSuperState
    {
        public MoveSubState(PlayerController playerController, string parameterName) : base(playerController, parameterName)
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
            if (IsStateComplete) return;
            if (InputX == 0)
            {
                StateMachine.ChangeState(States.Idle);
            }
            else if (InputX != 0 && InputY < 0)
            {
                StateMachine.ChangeState(PlayerController.States.CrouchMove);
            }
            else if (InputX == 0 && InputY >= 0)
            {
                StateMachine.ChangeState(PlayerController.States.CrouchIdle);
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