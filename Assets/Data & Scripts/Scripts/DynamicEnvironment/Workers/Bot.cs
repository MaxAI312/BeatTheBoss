using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Bot : MonoBehaviour
{
    [SerializeField] private int _numberOfWorker;
    [SerializeField] protected Animator Animator; // rafactoring

    public event UnityAction Triggered;

    private const string Observe = nameof(Observe);

    public int NumberOfWorker => _numberOfWorker;

    public void DisableAnimator()
    {
        Animator.enabled = false;
    }

    public void EnableAnimator()
    {
        Animator.enabled = true;
    }

    public virtual void PlayAnimation()
    {
        Animator.SetTrigger(Observe);
    }

    private void Handle_AnimatorDisable()
    {
        DisableAnimator();
    }
}
