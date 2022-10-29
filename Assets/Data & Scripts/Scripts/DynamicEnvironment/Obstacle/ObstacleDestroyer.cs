using System;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidbodies;

    public event Action Destroyed;

    public void MakePhysics()
    {
        Destroyed?.Invoke();
        foreach (var rigidbody in _rigidbodies)
            rigidbody.isKinematic = false;
    }
}
