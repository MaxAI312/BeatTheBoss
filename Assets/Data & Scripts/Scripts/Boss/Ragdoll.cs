using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private Transform _grenadeTargetPoint;
    [SerializeField] private Rigidbody[] _allRigidbodies;

    private BossAnimator _bossAnimator;
    
    public Transform GrenadeTargetPoint => _grenadeTargetPoint;

    private void Awake()
    {
        foreach (var rigidbody in _allRigidbodies) rigidbody.isKinematic = true;
    }

    public void Initialize(BossAnimator bossAnimator)
    {
        _bossAnimator = bossAnimator;
    }

    public void MakePhysics()
    {
        _bossAnimator.Disable();
        foreach (var rigidbody in _allRigidbodies)
        {
            rigidbody.isKinematic = false;
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        } 
    }
}