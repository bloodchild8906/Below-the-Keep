using Player.FiniteStateMachine.States.SuperStates;

namespace Player.FiniteStateMachine.States.SubStates.Ability
{
    public class JumpSubState:AbilitySuperState
    {
        public JumpSubState(PlayerController playerController, string parameterName) : base(playerController, parameterName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Movement.SetVelocity_Y(Data.jumpStrength);
            IsComplete = true;
        }
    }
}