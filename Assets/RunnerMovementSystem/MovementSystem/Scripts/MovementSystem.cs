using System;
using UnityEngine;
using UnityEngine.Events;
using RunnerMovementSystem.Model;

namespace RunnerMovementSystem
{
    public class MovementSystem : MonoBehaviour
    {
        [SerializeField] private RoadSegment _firstRoad;
        [SerializeField] private MovementOptions _options;

        private MovementBehaviour _movementBehaviour;
        private RoadMovement _roadMovement;
        private TransitionMovement _transitionMovement;
        private IMovement _currentMovement;

        public event UnityAction<PathSegment> PathChanged;
        public event Action RoadEndReached;

        public float Offset => _currentMovement.Offset;
        public float CurrentSpeed => _movementBehaviour.GetCurrentSpeed();
        public bool IsOnTransition => _currentMovement is TransitionMovement;
        public PathSegment CurrentRoad => _currentMovement.PathSegment;
        public float DefaultSpeed => _options.MoveSpeed;

        private void Awake()
        {
            _movementBehaviour = new MovementBehaviour(transform, _options);

            _roadMovement = new RoadMovement(_movementBehaviour);
            _transitionMovement = new TransitionMovement(_movementBehaviour);
        }

        private void OnEnable()
        {
            _roadMovement.EndReached += OnRoadEnd;
            _transitionMovement.EndReached += OnTransitionEnd;
        }

        private void OnDisable()
        {
            _roadMovement.EndReached -= OnRoadEnd;
            _transitionMovement.EndReached -= OnTransitionEnd;
        }

        private void Start()
        {
            if (_firstRoad)
                Init(_firstRoad);
        }

        private void Update()
        {
            _currentMovement?.Update();
        }

        public void Init(RoadSegment firstRoad)
        {
            _firstRoad = firstRoad;
            _roadMovement.Init(_firstRoad);
            _currentMovement = _roadMovement;
        }

        public void MoveForward()
        {
            if (enabled)
                _currentMovement.MoveForward();
        }

        public void SetOffset(float offset)
        {
            if (enabled)
                _currentMovement.SetOffset(offset);
        }

        public void Transit(TransitionSegment transition)
        {
            _transitionMovement.Init(transition);
            _currentMovement = _transitionMovement;

            PathChanged?.Invoke(transition);
        }

        public void SetSpeed(float value)
        {
            _options.SetSpeed(value);
        }

        private void OnRoadEnd(RoadSegment roadSegment)
        {
            var nearestRoad = roadSegment.GetNearestRoad(transform.position);
            if (nearestRoad == null)
            {
                RoadEndReached?.Invoke();
                return;
            }

            _roadMovement.Init(nearestRoad);
            _currentMovement = _roadMovement;

            PathChanged?.Invoke(nearestRoad);
        }

        private void OnTransitionEnd(TransitionSegment transition)
        {
            var nearestRoad = transition.GetNearestRoad(transform.position);
            _roadMovement.Init(nearestRoad);
            _currentMovement = _roadMovement;

            PathChanged?.Invoke(nearestRoad);
        }
    }
}