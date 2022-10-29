using UnityEngine;
using System;
using DG.Tweening;

public class ReactionsSwitcher : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transformable _transformable;

    public void OnSlaped(int indexAnimation)
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendCallback(() =>
        {
            if (indexAnimation == 2)//MAGIC INT
                SetHighReaction();

            else if (indexAnimation == 1)//MAGIC INT
                SetMiddleReaction();

            else if (indexAnimation == 0)//MAGIC INT
                SetLowReaction();

            else
                SetDefaultReaction();
        });
    }

    private void SetHighReaction()
    {
        _transformable.Press();
        _animator.SetTrigger("Press");//MAGIC STRING
    }

    private void SetMiddleReaction()
    {
        _transformable.Push();
        _animator.SetTrigger("Push");//MAGIC STRING
    }

    private void SetLowReaction()
    {
        _transformable.Toss();
        _animator.SetTrigger("Toss");//MAGIC STRING
    }

    private void SetDefaultReaction()
    {
        _transformable.Push();
        _animator.SetTrigger("Walk");//MAGIC STRING
    }
}
