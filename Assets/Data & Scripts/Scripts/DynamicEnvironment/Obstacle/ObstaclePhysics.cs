using UnityEngine;

public class ObstaclePhysics : MonoBehaviour, IPhysics
{
    [SerializeField] private Rigidbody[] _rigidbodies;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            MakePhysics();
        }
    }

    public void MakePhysics()
    {
        foreach (var rb in _rigidbodies)
            rb.isKinematic = false;
    }
}
