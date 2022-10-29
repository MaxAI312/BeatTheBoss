using UnityEngine;

public class WallPhysics : MonoBehaviour, IPhysics
{
    [SerializeField] private Rigidbody[] _rigidbodies;

    private bool _isDestroyable = true;

    public void MakePhysics()
    {
        if (_isDestroyable == false)
            return;

        foreach (var rb in _rigidbodies)
            rb.isKinematic = false;
    }

    public void MakeWallNotDestroyable()
    {
        _isDestroyable = false;
    }
}