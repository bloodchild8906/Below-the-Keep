using Player.FiniteStateMachine.States.SuperStates;
using UnityEngine;

namespace Player.FiniteStateMachine.States.SubStates.Ability
{
    public class WallJumpSubState:AbilitySuperState
    {
        public WallJumpSubState(PlayerController playerController, string parameterName) : base(playerController, parameterName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            if (IsStateComplete) return;

            States.Jump.ResetJumps();
            Movement.SetVelocity(Data.walljumpStrength, Data.wallJumpAngle, (int)-PlayerController.Transform.localScale.x);
            Movement.Flip((int)-PlayerController.Transform.localScale.x);
            States.Jump.DecreaseJumps();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (IsStateComplete) return;

            Animator.SetFloat(Data.animationParameters.yVelocity, Movement.CurrentVelocity.y);
            if (Time.time >= StartTime + Data.WallJumpTime)
                IsComplete = true;
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