using UnityEngine;
using DG.Tweening;

public class ReactionsSwitcher : MonoBehaviour
{
    private const string Press = nameof(Press);
    private const string Push = nameof(Push);
    private const string Toss = nameof(Toss);
    private const string Walk = nameof(Walk);
    
    [SerializeField] private Animator _animator;
    [SerializeField] private Transformable _transformable;

    private int indexHighAnimation = 2;
    private int indexMiddleAnimation = 1;
    private int indexLowAnimation = 0;

    public void OnSlaped(int indexAnimation)
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendCallback(() =>
        {
            if (indexAnimation == indexHighAnimation)
                SetHighReaction();

            else if (indexAnimation == indexMiddleAnimation)
                SetMiddleReaction();

            else if (indexAnimation == indexLowAnimation)
                SetLowReaction();

            else
                SetDefaultReaction();
        });
    }

    private void SetHighReaction()
    {
        _transformable.Press();
        _animator.SetTrigger(Press);
    }

    private void SetMiddleReaction()
    {
        _transformable.Push();
        _animator.SetTrigger(Push);
    }

    private void SetLowReaction()
    {
        _transformable.Toss();
        _animator.SetTrigger(Toss);
    }

    private void SetDefaultReaction()
    {
        _transformable.Push();
        _animator.SetTrigger(Walk);
    }
}
