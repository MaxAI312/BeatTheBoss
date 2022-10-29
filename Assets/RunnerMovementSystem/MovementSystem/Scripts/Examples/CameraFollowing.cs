using UnityEngine;

namespace RunnerMovementSystem.Examples
{
    public class CameraFollowing : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;
        [Space(15)]
        [SerializeField] private Transform _targetPlayer;
        [SerializeField] private Transform _targetBoss;
        [SerializeField] private float _height;
        [SerializeField] private float _distance;
        [SerializeField] private float _lookAngle;

        private Vector3 _targetPosition;
        private bool _isBossCamera = false;
        private bool _isPlayerCamera = true;

        private void LateUpdate()
        {
            if (_isPlayerCamera)
            {
                //Debug.Log("_isPlayerCamera");
                _targetPosition = _targetPlayer.position;
                _targetPosition -= _targetPlayer.forward * _distance;
                _targetPosition += Vector3.up * _height;
                transform.position = Vector3.Lerp(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);

                var targetRotation = Quaternion.LookRotation(_targetPlayer.forward, Vector3.up);
                targetRotation.eulerAngles = new Vector3(_lookAngle, targetRotation.eulerAngles.y, targetRotation.eulerAngles.z);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            }
            else if (_isBossCamera)
            {
                //Debug.Log("_isBossCamera");
                _targetPosition = _targetBoss.position;
                _targetPosition -= _targetBoss.forward * _distance;
                _targetPosition += Vector3.up * _height;
                transform.position = Vector3.Lerp(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);

                var targetRotation = Quaternion.LookRotation(_targetBoss.forward, Vector3.up);
                targetRotation.eulerAngles = new Vector3(_lookAngle, targetRotation.eulerAngles.y, targetRotation.eulerAngles.z);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            }
        }

        public void EnableBossCamera()
        {
            _isBossCamera = true;
            _isPlayerCamera = false;
        }

        public void EnablePlayerCamera()
        {
            _isBossCamera = false;
            _isPlayerCamera = true;
        }
    }
}