using Player;
using Player.Config;
using Player.FiniteStateMachine;
using Player.FiniteStateMachine.States.Base;
using Player.FiniteStateMachine.States.SubStates.Grounded;
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

        private PlayerController _playerController;
        public StateDataModel(PlayerController playerController)
        {
            _playerController = playerController;
            InitialiseStates();
        }
        private void InitialiseStates()
        {
            Idle = new IdleSubState(_playerController, "Idle");
            Move = new MoveSubState(_playerController, "Run");
        }
    }
}