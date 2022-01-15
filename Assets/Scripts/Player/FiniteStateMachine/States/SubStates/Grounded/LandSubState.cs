using Player.FiniteStateMachine.States.SuperStates;

namespace Player.FiniteStateMachine.States.SubStates.Grounded
{
    public class LandSubState:GroundedSuperState
    {
        public LandSubState(PlayerController playerController, string parameterName) : base(playerController, parameterName)
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