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

        protected float StartTime { get; private set; }

        protected Animator Animator => PlayerController.Animator;
        protected StateDataModel States => PlayerController.States;
        protected StateMachine StateMachine => PlayerController.StateMachine;
        protected PlayerData Data => PlayerController.playerData;
        protected Movement Movement => PlayerController.Movement;
        protected Checks Checks => PlayerController.Checks;
        protected InputManager Input => PlayerController.Input;

        protected int InputX { get; private set; }
        protected int InputY { get; private set; }

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

        }
        public virtual void Exit()
        {
            Animator.SetBool(_animationParameter, false);
        }
        public virtual void LogicUpdate()
        {
            InputX = Input.X;
            InputY = Input.Y;
        }
        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }
        protected virtual void DoChecks()
        {

        }


    }
}