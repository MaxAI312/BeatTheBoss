using UnityEngine;

public class ParticleHandsColliders : MonoBehaviour
{
    [SerializeField] private Collider[] _colliders;

    public void EnableColliders()
    {
        for (int i = 0; i < _colliders.Length; i++)
        {
            _colliders[i].enabled = false;
        }
    }

    public void DisableColliders()
    {
        for (int i = 0; i < _colliders.Length; i++)
        {
            _colliders[i].enabled = false;
        }
    }
}
