using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GateGirlAnimator : MonoBehaviour
{
    private Animator _animator;
    private const string GateOff = nameof(GateOff);

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

    public void PlayGateOff()
    {
        _animator.SetTrigger(GateOff);
    }
}
