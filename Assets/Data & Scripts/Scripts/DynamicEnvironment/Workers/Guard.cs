using UnityEngine;
using DG.Tweening;

public class Guard : Bot
{
    private bool _isStop = false;
    private const string LeftSide = nameof(LeftSide);
    private const string RightSide = nameof(RightSide);

    public override void PlayAnimation()
    {
        base.PlayAnimation();
        Sequence sequence = DOTween.Sequence();

        sequence.AppendCallback(() =>
        {
            Animator.SetBool(LeftSide, true);
            Animator.SetBool(RightSide, false);
        });

        sequence.Append(transform.DOLocalMoveX(transform.localPosition.x - 4f, 1.5f));//MAGIC INT

        sequence.AppendCallback(() =>
        {
            Animator.SetBool(LeftSide, false);
            Animator.SetBool(RightSide, true);
        });

        sequence.Append(transform.DOLocalMoveX(transform.localPosition.x + 4f, 1.5f));//MAGIC INT

        sequence.AppendCallback(() =>
        {
            Animator.SetBool(LeftSide, true);
            Animator.SetBool(RightSide, false);
        });

        sequence.Append(transform.DOLocalMoveX(transform.localPosition.x - 4f, 1.5f));//MAGIC INT
        sequence.AppendCallback(() => DisableAnimator());

        if (_isStop)
        {
            sequence.Kill();
        }
    }

    public void StopAnimation()
    {
        _isStop = true;
    }
}
