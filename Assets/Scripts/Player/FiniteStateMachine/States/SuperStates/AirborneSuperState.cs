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

            if (Checks.IsGrounded && Movement.CurrentVelocity.y < 0.01f|| (Checks.IsGrounded && !Checks.WallContact && !Checks.LedgeContact))
            {
                StateMachine.ChangeState(States.Land);
            }
            else if (Checks.WallContact && !Checks.LedgeContact && Movement.CurrentVelocity.y <= 0 && !Checks.IsGrounded)
            {
                States.LedgeClimb.SavePosition(PlayerController.Transform.position);

                StateMachine.ChangeState(States.LedgeClimb);
            }
            else if (JumpInput && Checks.WallContact)
            {
                Input.UseJumpInput();
                StateMachine.ChangeState(States.WallJump);
            }
            else if (States.Jump.CanJump && JumpInput)
            {
                Input.UseJumpInput();
                StateMachine.ChangeState(States.Jump);
            }
            else if (Checks.WallContact && InputX == PlayerController.transform.localScale.x && Movement.CurrentVelocity.y <= 0f)
            {
                StateMachine.ChangeState(States.WallSlide);
            }
            else if (DashInput && Checks.CanDash())
            {
                StateMachine.ChangeState(States.Dash);
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
            if (Checks.WallContact && !Checks.LedgeContact)
            {
                States.LedgeClimb.SavePosition(PlayerController.transform.position);
            }
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