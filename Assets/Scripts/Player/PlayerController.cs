using Data.Models;
using Player.Config;
using Player.FiniteStateMachine;
using Player.FiniteStateMachine.States.SubStates.Grounded;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerData playerData;

        public StateMachine StateMachine { get; private set; }
        public Animator Animator { get; private set; }
        public Transform Transform { get; private set; }
        public StateDataModel States { get; private set; }
        public InputManager Input { get; set; }

        private void Awake()
        {
            StateMachine = new StateMachine();
            States = new StateDataModel(this);
            CacheComponents();
        }
        private void Start()
        {
            StateMachine.Initialise(States.Idle);
        }
        private void Update() => StateMachine.CurrentState.LogicUpdate();
        private void FixedUpdate() => StateMachine.CurrentState.PhysicsUpdate();

        private void CacheComponents()
        {
            Animator = GetComponent<Animator>();
            Transform= GetComponent<Transform>();
            Input = GetComponent<InputManager>();
        }
    }
}