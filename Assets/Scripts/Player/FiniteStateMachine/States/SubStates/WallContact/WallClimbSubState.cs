using Player.FiniteStateMachine.States.SuperStates;

namespace Player.FiniteStateMachine.States.SubStates.WallContact
{
    public class WallClimbSubState:WallContactSuperState
    {
        public WallClimbSubState(PlayerController playerController, string parameterName) : base(playerController, parameterName)
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
            if (!Checks.LedgeContact)
            {
                States.LedgeClimb.SavePosition(PlayerController.Transform.position);
                StateMachine.ChangeState(States.LedgeClimb);
            }
            if (InputY>0)
                Movement.SetVelocity_Y(Data.wallClimbSpeed);
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