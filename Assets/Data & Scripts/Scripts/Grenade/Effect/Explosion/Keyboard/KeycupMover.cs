using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class KeycupMover : MonoBehaviour
{
    [SerializeField] private float _delayBeforeMovement = 4.25f;
    [SerializeField] private float _durationMovement = 0.55f;

    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    public void MoveAfterFalling()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(_delayBeforeMovement);
        sequence.Append(transform.DOMove(_startPosition, _durationMovement));
    }
}
