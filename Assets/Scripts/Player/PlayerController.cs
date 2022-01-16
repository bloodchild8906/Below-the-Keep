using Core;
using Data.Models;
using Player.Config;
using Player.FiniteStateMachine;
using Player.FiniteStateMachine.States.SubStates.Grounded;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerData playerData;
        public Transform groundCheck;
        public Transform wallCheck;
        public Transform ledgeCheck;

        [ShowInInspector, ReadOnly]
        public bool IsGounded { get; set; }
        
        [ShowInInspector, ReadOnly]
        public bool IsWallContact { get; set; }



        public StateMachine StateMachine { get; private set; }
        public Animator Animator { get; private set; }
        public Rigidbody2D Rigidbody { get; private set; }
        public Transform Transform { get; private set; }
        public StateDataModel States { get; private set; }
        public Movement Movement { get; set; }
        public InputManager Input { get; set; }
        public Checks Checks { get; set; }


        private void Awake()
        {
            CacheComponents();
            StateMachine = new StateMachine();
            States = new StateDataModel(this);
            Movement = new Movement(this);
            Checks = new Checks(this);
        }
        private void Start()
        {
            StateMachine.Initialise(States.Idle);
        }
        private void Update()
        {
            IsGounded = Checks.IsGrounded;
            IsWallContact = Checks.WallContact;
            Movement.CurrentVelocity = Rigidbody.velocity;
            StateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate() => StateMachine.CurrentState.PhysicsUpdate();


        public void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

        public void AnimationCompleteTrigger() => StateMachine.CurrentState.AnimationCompleteTrigger();


        private void CacheComponents()
        {
            Animator = GetComponent<Animator>();
            Transform= GetComponent<Transform>();
            Input = GetComponent<InputManager>();
            Rigidbody = GetComponent<Rigidbody2D>();
        }
        
    }
}