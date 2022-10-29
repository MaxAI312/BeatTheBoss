using UnityEngine;

public class RagdollGuard : MonoBehaviour, IPhysics
{
    [SerializeField] private Rigidbody[] _allRigidbodies;
    [SerializeField] private Animator _animator;
    [SerializeField] private Guard _guard;

    private Transform _bossTransform;
    //refactoring
    public void Initialize(Transform rootTransform, BossAnimator bossAnimator)
    {
        _bossTransform = rootTransform;
    }

    private void Awake()
    {

        foreach (var rigidbody in _allRigidbodies) rigidbody.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        MakePhysics();
        _guard.StopAnimation();
    }

    public void MakePhysics()
    {
        _animator.enabled = false;
        foreach (var rigidbody in _allRigidbodies) rigidbody.isKinematic = false;
    }
}
