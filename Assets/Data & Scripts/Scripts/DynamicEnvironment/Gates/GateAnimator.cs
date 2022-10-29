using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GateAnimator : MonoBehaviour, IAnimationable
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void DisableAnimator()
    {
        _animator.enabled = false;
    }

    public void EnableAnimator()
    {
        _animator.enabled = true;
    }

    private void Handle_AnimatorDisable()
    {
        DisableAnimator();
    }
}
