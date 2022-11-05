using UnityEngine;
using DG.Tweening;

public class TrapMover : MonoBehaviour
{
    [SerializeField] private bool _isWorking;
    [SerializeField] private ObstacleDestroyer _obstacleDestroyer;
    [SerializeField] private bool _isLeft;
    [SerializeField] private bool _isRight;

    private Sequence _sequence;
    private float _offsetX = 7f;
    private float _durationOffsetX = 3f;
    private int _negativeDirectionMultiplier = -1;
    private int _positiveDirectionMultiplier = 1;

    private void Awake()
    {
        _sequence = DOTween.Sequence();
    }

    private void OnEnable()
    {
        _obstacleDestroyer.Destroyed += OnDestroyed;

        if (_isWorking)
            Move();
    }

    private void OnDisable()
    {
        _obstacleDestroyer.Destroyed -= OnDestroyed;
    }

    public void Move()
    {
        if (_isRight)
        {
            Offset(_negativeDirectionMultiplier);
        }
        else if (_isLeft)
        {
            Offset(_positiveDirectionMultiplier);
        }
    }

    public void Enable()
    {
        enabled = true;
    }

    public void Disable()
    {
        enabled = false;
    }

    private void OnDestroyed()
    {
        _sequence.Kill();
    }

    private void Offset(int directionMultiplier)
    {
        _sequence.Append(transform.DOMoveX(transform.position.x + _offsetX * directionMultiplier, _durationOffsetX));
        _sequence.Append(transform.DOMoveX(transform.position.x, _durationOffsetX));
        _sequence.SetLoops(-1, LoopType.Restart);
    }
}
