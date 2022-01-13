using Player.Config;
using Player.FiniteStateMachine;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerData playerData;

        private StateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = new StateMachine();
        }
        private void Start()
        {
            
        }
        private void Update() => _stateMachine.CurrentState.PhysicsUpdate();
        private void FixedUpdate() => _stateMachine.CurrentState.LogicUpdate();
    }
}