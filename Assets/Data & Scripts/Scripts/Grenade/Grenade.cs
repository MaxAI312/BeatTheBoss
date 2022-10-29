using System;
using System.Collections;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private AnimationCurve _yCurve;
    [SerializeField] private float _moveDuration;
    [SerializeField] private float _damageValue;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private Scaler _scaler;
    [SerializeField] private FinisherScaler _finisherScaler;

    private Action _grenadeDestroyed;
    private Coroutine _moveCoroutine;
    private Transform _trackedTransform;
    private Boss _boss;

    public float DamageValue => _damageValue;
    public float MoveDuration => _moveDuration;
    public Scaler Scaler => _scaler;
    public FinisherScaler FinisherScaler => _finisherScaler;

    private void Awake()
    {
        _trackedTransform = null;
    }

    private void Start()
    {
        _boss = FindObjectOfType<Boss>();
    }

    private void Update()
    {
        if (_trackedTransform != null)
        {
            transform.position = _trackedTransform.position;
            transform.rotation = _trackedTransform.rotation;
        }
    }

    public void Initialization(Transform transform)
    {
        _trackedTransform = transform;
    }

    public void DropTo(Vector3 targetPoint, Action targetTaken)
    {
        _grenadeDestroyed = targetTaken;
        _trackedTransform = null;
        _moveCoroutine = StartCoroutine(MoveTo(targetPoint));
    }

    public void Destroy()
    {
        if (_moveCoroutine != null)
            StopCoroutine(_moveCoroutine);

        _trackedTransform = null;
        _explosion.Explode();
        _grenadeDestroyed?.Invoke();
    }

    private IEnumerator MoveTo(Vector3 target)
    {
        var startPoint = transform.position;
        var bossStartPosition = _boss.transform.position;

        for (float time = 0; time < _yCurve.keys[_yCurve.keys.Length - 1].time; time += Time.deltaTime / _moveDuration)
        {
            transform.position = Vector3.LerpUnclamped(startPoint, target, time) +
                                 new Vector3(0, _yCurve.Evaluate(time), 0);
            
            //transform.position += _boss.transform.position - bossStartPosition;

            transform.position += _boss.transform.forward * _boss.Speed/2 * time;
            
            yield return null;
        }
        Debug.Log("Тут выше, надо немного подумать над броском");

        Destroy();
    }
}