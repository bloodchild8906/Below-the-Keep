using Player;
using Player.Config;
using Player.FiniteStateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Models
{
    public class StateDataModel
    {
        public PlayerController playerController { get; private set; }
        public PlayerData PlayerData { get; private set; }
        public StateMachine StateMachine { get; private set; }

    }
}