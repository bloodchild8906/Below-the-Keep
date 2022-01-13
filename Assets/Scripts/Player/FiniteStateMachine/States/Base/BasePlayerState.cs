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
        protected PlayerData PlayerData { get; private set; }
        protected StateMachine StateMachine { get; private set; }
        protected Animator Animator { get; private set; }
        protected Transform Transform { get; private set; }
        protected float StartTime { get; private set; }
        #endregion

        private string _animationParameter;
        
        protected BasePlayerState(PlayerController playerController, string animationParameter)
        {
            PlayerController = playerController;
            PlayerData = PlayerController.playerData;
            StateMachine = PlayerController.StateMachine;
            Animator = PlayerController.Animator;
            Transform = PlayerController.Transform;
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

        }
        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }
        public virtual void DoChecks()
        {

        }


    }
}