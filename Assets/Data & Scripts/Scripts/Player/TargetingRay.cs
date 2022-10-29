using UnityEngine;

public class TargetingRay : MonoBehaviour
{
    [SerializeField] private ParticleSystem _targetingPoint;

    private RayInput _rayInput;

    private void OnEnable()
    {
        if (_rayInput != null)
            _rayInput.TargetPointDetected += OnTargetDetected;
    }

    private void OnDisable()
    {
        if (_rayInput != null)
            _rayInput.TargetPointDetected -= OnTargetDetected;
    }

    public void Initialization(RayInput rayInput)
    {
        _rayInput = rayInput;
    }

    private void OnTargetDetected(bool isDetected)
    {
        if (isDetected)
            _targetingPoint.gameObject.SetActive(true);
        else
            _targetingPoint.gameObject.SetActive(false);

        _targetingPoint.transform.position = _rayInput.TargetPoint;
        transform.LookAt(_rayInput.TargetPoint);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}