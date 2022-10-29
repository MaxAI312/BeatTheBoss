using System;
using System.Collections;
using UnityEngine;

namespace RunnerMovementSystem.Examples
{
    public class MouseInput : MonoBehaviour
    {
        [SerializeField] private MovementSystem _roadMovement;
        [SerializeField] private float _sensitivity = 0.01f;
        [SerializeField] private float _returningToDefaultPositionDuration;
        private bool _isControlled = true;
        private float _saveOffset;

        public bool IsMoved { get; private set; }
        public float TurnValue { get; private set; }

        private void Update()
        {
            _roadMovement.MoveForward();

            if (_isControlled == false)
                return;

            if (Input.GetMouseButtonDown(0))
            {
                IsMoved = true;
            }

            if (Input.GetMouseButton(0))
            {
                var MouseDeltaX = Input.GetAxis("Mouse X");

                TurnValue = MouseDeltaX;

                _saveOffset += MouseDeltaX * _sensitivity;
                _roadMovement.SetOffset(_saveOffset);
            }

            if (Input.GetMouseButtonUp(0))
            {
                IsMoved = false;
                TurnValue = 0;
            }
        }

        private void OnEnable()
        {
            _roadMovement.PathChanged += OnPathChanged;
        }

        private void OnDisable()
        {
            _roadMovement.PathChanged -= OnPathChanged;
        }

        public void ReturnToDefaultPosition(Action defaultPositionGetted)
        {
            StopControl();
            StartCoroutine(ReturningToDefaultPosition(defaultPositionGetted));
        }

        public void StartControl()
        {
            _isControlled = true;
        }

        public void StopControl()
        {
            _isControlled = false;
        }

        private void OnPathChanged(PathSegment _)
        {
            _saveOffset = _roadMovement.Offset;
        }

        private IEnumerator ReturningToDefaultPosition(Action defaultPositionGetted)
        {
            var startOffset = _roadMovement.Offset;
            TurnValue = 0;

            for (float i = 0; i < 1; i += Time.deltaTime / _returningToDefaultPositionDuration)
            {
                var offset = Mathf.Lerp(startOffset, 0, i);
                _roadMovement.SetOffset(offset);

                yield return null;
            }

            defaultPositionGetted?.Invoke();
        }
    }
}