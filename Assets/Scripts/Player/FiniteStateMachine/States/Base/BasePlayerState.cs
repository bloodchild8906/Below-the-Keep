using Core;
using Data.Models;
using Player.Config;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.FiniteStateMachine.States.Base
{
    public abstract class BasePlayerState
    {
        #region protected properties
        protected PlayerController PlayerController { get; private set; }

        protected float StartTime { get; set; }
        protected bool IsStateComplete { get; private set; }

        protected Animator Animator => PlayerController.Animator;
        protected StateDataModel States => PlayerController.States;
        protected StateMachine StateMachine => PlayerController.StateMachine;
        protected PlayerData Data => PlayerController.playerData;
        protected Movement Movement => PlayerController.Movement;
        protected Checks Checks => PlayerController.Checks;
        protected InputManager Input => PlayerController.Input;

        protected int InputX { get; private set; }
        protected int InputY { get; private set; }
        protected Vector2 DashMovementInput { get; private set; }
        protected bool JumpInput { get; private set; }
        protected bool JumpStop { get; private set; }
        protected bool WallGrab { get; private set; }
        protected bool DashInput { get; private set; }
        protected bool DashInputStop { get; private set; }


        protected bool AnimationComplete { get; private set; }

        #endregion

        private string _animationParameter;
        
        protected BasePlayerState(PlayerController playerController, string animationParameter)
        {
            PlayerController = playerController;
            _animationParameter = animationParameter;
        }
        public virtual void Enter()
        {
            DoChecks();
            Animator.SetBool(_animationParameter, true);
            StartTime = Time.time;
            AnimationComplete = false;
            IsStateComplete = false;

        }
        public virtual void Exit()
        {
            Animator.SetBool(_animationParameter, false);
            IsStateComplete = true;
        }
        public virtual void LogicUpdate()
        {
            InputX = Input.X;
            InputY = Input.Y;
            JumpInput = Input.JumpInput;
            JumpStop = Input.JumpInputStop;
            WallGrab = Input.GrabInput;
            DashInput = Input.DashInput;
            DashInputStop = Input.DashInputStop;
            DashMovementInput = Input.RawDashDirectionInput;
        }
        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }
        protected virtual void DoChecks()
        {

        }
        public virtual void AnimationTrigger()
        {

        }

        public virtual void AnimationCompleteTrigger() => AnimationComplete = true;

    }
}