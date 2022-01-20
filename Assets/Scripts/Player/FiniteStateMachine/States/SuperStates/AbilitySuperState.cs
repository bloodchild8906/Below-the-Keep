using Player.FiniteStateMachine.States.Base;

namespace Player.FiniteStateMachine.States.SuperStates
{
    public class AbilitySuperState : BasePlayerState
    {
        protected bool IsComplete { get; set; }
        public AbilitySuperState(PlayerController playerController, string parameterName) : base(playerController, parameterName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            IsComplete = false;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (IsComplete)
            {
                if (Checks.IsGrounded && Movement.CurrentVelocity.y < 0.1f)
                {
                    StateMachine.ChangeState(States.Idle);
                }
                else
                {
                    StateMachine.ChangeState(States.Airborne);
                }
                
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