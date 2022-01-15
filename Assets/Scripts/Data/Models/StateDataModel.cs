using Player;
using Player.Config;
using Player.FiniteStateMachine;
using Player.FiniteStateMachine.States.Base;
using Player.FiniteStateMachine.States.SubStates.Ability;
using Player.FiniteStateMachine.States.SubStates.Grounded;
using Player.FiniteStateMachine.States.SuperStates;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Models
{
    public class StateDataModel
    {
        public IdleSubState Idle { get; set; }
        public MoveSubState Move { get; set; }
        public LandSubState Land { get; set; }
        public JumpSubState Jump { get; set; }
        public AirborneSuperState Airborne { get; set; }

        private PlayerController _playerController;
        private PlayerAnimations _animation => _playerController.playerData.animationParameters;
        public StateDataModel(PlayerController playerController)
        {
            _playerController = playerController;
            InitialiseStates();
        }
        private void InitialiseStates()
        {
            Idle = new IdleSubState(_playerController, _animation.idle);
            Move = new MoveSubState(_playerController, _animation.move);
            Land = new LandSubState(_playerController, _animation.land);
            Jump = new JumpSubState(_playerController, _animation.jump);
            Airborne = new AirborneSuperState(_playerController, _animation.airborne);

        }
    }
}