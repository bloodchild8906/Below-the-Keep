using Player.FiniteStateMachine.States.Base;
using UnityEngine;

namespace Player.FiniteStateMachine.States.SuperStates
{
    public class LedgeClimbSuperState : BasePlayerState
    {
        private Vector2 _savedPos;
        private Vector2 _cornerPos;
        private Vector2 _startPos;
        private Vector2 _endPos;
        private bool _isHanging;
        private bool _isClimbing;
        public LedgeClimbSuperState(PlayerController playerController, string parameterName) : base(playerController, parameterName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Movement.SetVelocityZero();
            PlayerController.Transform.position = _savedPos;
            _cornerPos = Checks.GetCornerPos();
            _startPos.Set(_cornerPos.x - (PlayerController.transform.localScale.x * Data.startOffset.x), _cornerPos.y - Data.startOffset.y);
            _endPos.Set(_cornerPos.x + (PlayerController.transform.localScale.x * Data.endOffset.x), _cornerPos.y + Data.endOffset.y);
            PlayerController.Transform.position = _startPos;
        }

        public override void Exit()
        {
            base.Exit();
            _isHanging = false;
            if (_isClimbing)
            {
                PlayerController.Transform.position = _endPos;
                _isClimbing = false;
            }
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            Movement.SetVelocityZero();
            PlayerController.Transform.position = _startPos;
            if (AnimationComplete)
            {
                StateMachine.ChangeState(States.Idle);
            }
            else
            {
                if (InputX == PlayerController.Transform.localScale.x && _isHanging && !_isClimbing)
                {
                    _isClimbing = true;
                    Animator.SetBool(Data.animationParameters.ledgeClimb, true);
                }
                else if (InputY == -1 && _isHanging && !_isClimbing)
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
        public void SavePosition(Vector2 posistion) => _savedPos = posistion;

        public override void AnimationTrigger()
        {
            base.AnimationTrigger();
            _isHanging = true;
        }

        public override void AnimationCompleteTrigger()
        {
            base.AnimationCompleteTrigger();
            Animator.SetBool(Data.animationParameters.ledgeClimb, false);

        }
    }
}