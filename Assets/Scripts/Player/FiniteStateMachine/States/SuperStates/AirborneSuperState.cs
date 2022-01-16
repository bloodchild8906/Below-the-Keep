using Player.FiniteStateMachine.States.Base;
using UnityEngine;

namespace Player.FiniteStateMachine.States.SuperStates
{
    public class AirborneSuperState : BasePlayerState
    {
        private bool _isJumping;
        private bool _coyoteTime;

        public AirborneSuperState(PlayerController playerController, string parameterName) : base(playerController, parameterName)
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
            VariableJump();
            CheckCoyoteTime();

            if (Checks.IsGrounded && Movement.CurrentVelocity.y < 0.01f)
            {
                StateMachine.ChangeState(States.Land);
            }
            else if (States.Jump.CanJump && JumpInput)
            {
                StateMachine.ChangeState(States.Jump);
            }
            else if (Checks.WallContact && InputX == PlayerController.transform.localScale.x&&Movement.CurrentVelocity.y<=0f)
            {
                StateMachine.ChangeState(States.WallSlide);
            }
            else
            {
                Movement.Flip(InputX);
                Movement.SetVelocity_X(Data.moveSpeed * InputX);
                Animator.SetFloat(Data.animationParameters.yVelocity, Movement.CurrentVelocity.y);
            }
        }



        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        private void VariableJump()
        {
            if (_isJumping)
            {
                if (JumpStop && Movement.CurrentVelocity.y > 0)
                {
                    Movement.SetVelocity_Y(Movement.CurrentVelocity.y * Data.variableJumpModifier);
                }
                else
                {
                    _isJumping = false;
                }
                _coyoteTime = false;
            }
        }
        protected override void DoChecks()
        {
            base.DoChecks();
        }
        public void SetJumping() => _isJumping = true;
        public void SetCoyoteTime() => _coyoteTime = true;
        private void CheckCoyoteTime()
        {
            if (_coyoteTime && Time.time > StartTime + Data.coyoteTime)
            {
                _coyoteTime = false;
                States.Jump.DecreaseJumps();
            }
        }

    }
}