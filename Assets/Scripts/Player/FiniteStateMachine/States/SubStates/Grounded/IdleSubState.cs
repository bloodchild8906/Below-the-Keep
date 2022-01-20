using Player.FiniteStateMachine.States.SuperStates;

namespace Player.FiniteStateMachine.States.SubStates.Grounded
{
    public class IdleSubState:GroundedSuperState
    {
        public IdleSubState(PlayerController playerController, string parameterName) : base(playerController, parameterName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Movement.SetVelocity_X(0);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (IsStateComplete) return;
            if (InputX != 0 && InputY == 0)
            {
                StateMachine.ChangeState(PlayerController.States.Move);
            }else if (InputX != 0 && InputY == -1)
            {
                StateMachine.ChangeState(PlayerController.States.CrouchMove);
            }
            else if (InputX == 0 && InputY == -1)
            {
                StateMachine.ChangeState(PlayerController.States.CrouchIdle);
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