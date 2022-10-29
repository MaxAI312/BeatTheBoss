using UnityEngine;

public class CameraDirector : MonoBehaviour
{
    [SerializeField] [Min(0)] private float _sensitivity;
    [SerializeField] private Transform _rotationPoint;

    private Vector3 _lastMousePosition;

    private void Awake()
    {
        Disable();
    }

    private void Update()
    {
        if (!Input.GetMouseButton(0)) return;
        
        var yRotation = Input.GetAxis("Mouse X");
        var xRotation = Input.GetAxis("Mouse Y");

        transform.RotateAround(_rotationPoint.position, Vector3.up, yRotation * _sensitivity);
        transform.RotateAround(_rotationPoint.position, transform.right, -xRotation * _sensitivity);
    }

    public void Enable()
    {
        enabled = true;
    }

    public void Disable()
    {
        enabled = false;
    }
}