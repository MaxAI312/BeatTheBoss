using System;
using UnityEngine;
using static UnityEngine.Screen;

public class RayInput : MonoBehaviour
{
    [SerializeField] private float _castDistance;
    [SerializeField] private LayerMask _layerMask;

    private Camera _mainCamera;
    private int _widthDevider = 2;
    private int _heightDevider = 2;

    public Vector3 TargetPoint { get; private set; }

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        var ray = _mainCamera.ScreenPointToRay(new Vector3(width / _widthDevider, height / _heightDevider));

        if (Physics.Raycast(ray, out var hitInfo, _castDistance, _layerMask))
        {
            var boss = hitInfo.collider.GetComponent<Boss>();
            if (boss)
            {
                TargetPoint = hitInfo.point;
                TargetPointDetected?.Invoke(true);
            }
        }
        else
        {
            TargetPoint = ray.GetPoint(_castDistance);
            TargetPointDetected?.Invoke(false);
        }
    }

    public event Action<bool> TargetPointDetected;

    public void Enable()
    {
        enabled = true;
    }

    public void Disable()
    {
        enabled = false;
    }
}