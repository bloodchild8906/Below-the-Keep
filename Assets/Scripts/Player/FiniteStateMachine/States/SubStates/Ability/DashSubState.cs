using Player.FiniteStateMachine.States.SuperStates;
using UnityEngine;

namespace Player.FiniteStateMachine.States.SubStates.Ability
{
    public class DashSubState:AbilitySuperState
    {
        public bool CanDash { get; private set; }

        public float LastDashtime { get;private set; }
        private bool _isHolding;
        private Vector2 _dashDirection;
        private float _playerDrag = 0f;
        public DashSubState(PlayerController playerController, string parameterName) : base(playerController, parameterName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _playerDrag=PlayerController.Rigidbody.drag;
            PlayerController.directionIndicator.localScale = PlayerController.Transform.localScale;
            CanDash = false;
            Input.UseDashInput();
            _isHolding = true;
            _dashDirection = Vector2.right * PlayerController.Transform.localScale.x;
            Time.timeScale = Data.holdTimeScale;
            StartTime = Time.unscaledTime;
        }

        public override void Exit()
        {
            
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_isHolding)
            {
                PlayerController.directionIndicator.gameObject.SetActive(true);
                _dashDirection = DashMovementInput;
                _dashDirection.Normalize();
                var angle = Vector2.SignedAngle(Vector2.right, _dashDirection);
                PlayerController.directionIndicator.rotation = Quaternion.Euler(0, 0, angle-Data.dashIndicatorAngleOffset);
                if (DashInputStop || Time.unscaledTime >= StartTime + Data.holdTime)
                {
                    _isHolding = false;
                    PlayerController.directionIndicator.gameObject.SetActive(false);
                    Time.timeScale = 1;
                    StartTime = Time.time;
                    Movement.Flip(Mathf.RoundToInt(_dashDirection.x));
                    PlayerController.Rigidbody.drag = Data.dashDrag;
                    Movement.SetVelocity(Data.dashvelocity, _dashDirection);
                }
            }
            else
            {
                Movement.SetVelocity(Data.dashvelocity, _dashDirection);
                //if (Checks.WallContact||Checks.BackWallContact)
                //{
                //    Movement.SetVelocityZero();
                //    PlayerController.Rigidbody.drag = _playerDrag;
                //    IsComplete = true;
                //    LastDashtime = Time.time;

                //}
                //else 
                if (Time.time >= StartTime + Data.dashTime)
                {
                    PlayerController.Rigidbody.drag = _playerDrag;
                    IsComplete = true;
                    LastDashtime = Time.time;
                    if (Checks.IsGrounded)
                    {
                        Movement.SetVelocityZero();
                    }
                    if (Movement.CurrentVelocity.y > 0.1)
                    {
                        Movement.SetVelocity_Y(Movement.CurrentVelocity.y * Data.dashEndYMultiplier);
                    }
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
        public void ResetDash() => CanDash = true;
    }
}