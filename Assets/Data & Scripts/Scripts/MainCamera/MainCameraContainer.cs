using RunnerMovementSystem.Examples;
using UnityEngine;

public class MainCameraContainer : MonoBehaviour
{
    [SerializeField] private CameraDirector _cameraDirector;
    [SerializeField] private RayInput _rayInput;
    [SerializeField] private MainCameraAnimator _mainCameraAnimator;
    [SerializeField] private CameraFollowing _cameraFollowing;

    public CameraDirector CameraDirector => _cameraDirector;
    public RayInput RayInput => _rayInput;
    public MainCameraAnimator MainCameraAnimator => _mainCameraAnimator;
    public CameraFollowing CameraFollowing => _cameraFollowing;
    
    public void ResetCameraTransform()
    {
        _cameraDirector.transform.localPosition = Vector3.zero;
        _cameraDirector.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }
}