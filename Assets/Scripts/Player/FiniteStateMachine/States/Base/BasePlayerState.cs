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
        protected float StartTime { get; private set; }
        #endregion

        private string _animationParameter;
        
        protected BasePlayerState(PlayerController playerController, PlayerData playerData, StateMachine stateMachine,string animationParameter)
        {
            PlayerController = playerController;
            PlayerData = playerData;
            StateMachine = stateMachine;
            _animationParameter = animationParameter;
        }
        public virtual void Enter()
        {
            DoChecks();
            StartTime = Time.time;
        }
        public virtual void Exit()
        {

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