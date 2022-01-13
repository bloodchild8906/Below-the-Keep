using Player.FiniteStateMachine.States.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.FiniteStateMachine
{
    public class StateMachine
    {
        public BasePlayerState CurrentState { get; private set; }

        public void Initialise(BasePlayerState state)
        {
            CurrentState = state;
            CurrentState.Enter();
        }
        public void ChangeState(BasePlayerState state)
        {
            CurrentState.Exit();
            CurrentState = state;
            CurrentState.Enter();
        }

    }
}