using Player.FiniteStateMachine.States.SuperStates;

namespace Player.FiniteStateMachine.States.SubStates.Ability
{
    public class JumpSubState:AbilitySuperState
    {
        private int _amountOfJumpsLeft;
        public JumpSubState(PlayerController playerController, string parameterName) 
            : base(playerController, parameterName) => ResetJumps();

        public override void Enter()
        {
            base.Enter();
            if (IsStateComplete) return;

            Movement.SetVelocity_Y(Data.jumpStrength);
            IsComplete = true;
            States.Airborne.SetJumping();
            DecreaseJumps();
        }
        public bool CanJump => _amountOfJumpsLeft > 0;
        public void ResetJumps() => _amountOfJumpsLeft = Data.maxJumps;
        public void DecreaseJumps() => _amountOfJumpsLeft--;
    }
}