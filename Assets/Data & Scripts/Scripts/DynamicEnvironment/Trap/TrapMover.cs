using UnityEngine;
using DG.Tweening;
using System;

public class TrapMover : MonoBehaviour
{
    [SerializeField] private bool _isWorking;
    [SerializeField] private ObstacleDestroyer _obstacleDestroyer;
    [SerializeField] private bool _isLeft;
    [SerializeField] private bool _isRight;

    private Sequence _sequence;

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
            _sequence.Append(transform.DOMoveX(transform.position.x - 7f, 3f));//MAGIC INT
            _sequence.Append(transform.DOMoveX(transform.position.x, 3f));//MAGIC INT
            _sequence.SetLoops(-1, LoopType.Restart);
        }
        else if (_isLeft)
        {
            _sequence.Append(transform.DOMoveX(transform.position.x + 7f, 3f));//MAGIC INT
            _sequence.Append(transform.DOMoveX(transform.position.x, 3f));//MAGIC INT
            _sequence.SetLoops(-1, LoopType.Restart);
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
}
