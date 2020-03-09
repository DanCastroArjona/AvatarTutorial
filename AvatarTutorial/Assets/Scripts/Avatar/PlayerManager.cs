using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace AvatarTutorial.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Transform))]
    public sealed class PlayerManager : StateManager
    {
        static readonly string NORMALSTATE = "NormalState";
        static readonly string NARRATIVESTATE = "NarrativeState";


        #region Variables
        [BoxGroup("Controller variables")]
        public float movementSpeed, rotationSpeedCamOriented;
        [ReadOnly]
        public Vector3 moveDirection;
        [ReadOnly, BoxGroup("InputsMovement")]
        public float horizontal, vertical, moveAmount;
        [ReadOnly, BoxGroup("InputsInteraction")]
        public bool rightButton, leftButton, upButton, downButton,
            interactionButton;
        [ReadOnly, BoxGroup("StatesController")]
        public bool isInteractionActived;

        [Header("References")]
        private NavMeshAgent _navMeshAgent;
        private Rigidbody _rigidbody;
        private Transform _transform;

        public NavMeshAgent myNavMeshAgent { get { return _navMeshAgent; } }
        public Rigidbody myRigidbody { get { return _rigidbody; } }
        public Transform myTransform { get { return _transform; } }
        #endregion

        protected override void Init()
        {
            _transform = this.transform;
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _rigidbody = GetComponent<Rigidbody>();

            State normalState = new State(new List<StateAction>()
            {
                new Movement(this),
                new Inputs(this), 
                new Interaction(this)
            });

            State narrativeState = new State(new List<StateAction>()
            {
                new Movement(this),
                new Inputs(this)
            });


            RegisterState(NORMALSTATE, normalState);
            RegisterState(NARRATIVESTATE, narrativeState);
            SetState(NORMALSTATE);
        }

        private void Update()
        {
            UpdateState();
        }
    }
}