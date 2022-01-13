using Player.Config;
using Player.FiniteStateMachine;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerData playerData;

        public StateMachine StateMachine { get; private set; }
        public Animator Animator { get; private set; }
        public Transform Transform { get; private set; }

        private void Awake()
        {
            StateMachine = new StateMachine();
            CacheComponents();
            InitaliseStates();
        }
        private void Start()
        {
            
        }
        private void Update() => StateMachine.CurrentState.LogicUpdate();
        private void FixedUpdate() => StateMachine.CurrentState.PhysicsUpdate();

        private void CacheComponents()
        {
            Animator = GetComponent<Animator>();
            Transform= GetComponent<Transform>();
        }
        private void InitaliseStates()
        {

        }
    }
}