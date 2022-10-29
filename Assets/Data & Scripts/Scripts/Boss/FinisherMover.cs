using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FinisherMover : MonoBehaviour
{
    [SerializeField] [Min(0)] private float _moveDuration;

    private Transform _bossTransform;
    private Ragdoll _ragdoll;
    private IReadOnlyList<Wall> _walls;

    public void Initialize(Transform bossTransform, Ragdoll ragdoll, IReadOnlyList<Wall> walls)
    {
        _bossTransform = bossTransform;
        _ragdoll = ragdoll;
        _walls = walls;
    }

    public void PushToWallWith(int index, Action preLastWallTaken, Action moveEnded)
    {
        _walls[index].WallPhysics.MakeWallNotDestroyable();
        var sequence = DOTween.Sequence();

        for (var i = 0; i < index-1; i++)
            sequence.Append(_bossTransform
                .DOMove(_walls[i].BossTargetPoint, _moveDuration)
                .SetEase(Ease.Linear)
            );
        sequence.Append(_bossTransform
            .DOMove(_walls[index-1].BossTargetPointLast, _moveDuration)
            .SetEase(Ease.Linear));
        sequence.AppendCallback(() => preLastWallTaken?.Invoke());
        sequence.Append(_bossTransform.DOMove(_walls[index].BossTargetPointLast, _moveDuration).SetEase(Ease.Linear));
        sequence.AppendCallback(_ragdoll.MakePhysics);
        sequence.AppendInterval(1f);//MAGIC INT
        sequence.onComplete = () => moveEnded?.Invoke();
    }
}