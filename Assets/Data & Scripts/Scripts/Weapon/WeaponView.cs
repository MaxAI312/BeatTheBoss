using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Decreaser))]
public class WeaponView : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float _durationStep;
    private Decreaser _decresear;
    private bool _isRotated;

    private Rotater _rotater;
    private float _offsetY = 0.15f;

    private void Awake()
    {
        _rotater = GetComponentInParent<Rotater>();
        _decresear = GetComponent<Decreaser>();
    }

    private void Update()
    {
        if (_isRotated)
            _rotater.Rotate();
    }

    private void OnEnable()
    {
        _particleSystem.Play();
        PlayAnimation();
    }

    public void ShowDecrease()
    {
        _decresear.Decrease();
    }

    public void PlayAnimation()
    {
        Move();
        _isRotated = true;
    }

    private void Move()
    {
        var sequence = DOTween.Sequence();

        sequence.Append(transform.DOMoveY(transform.position.y + _offsetY, _durationStep));
        sequence.Append(transform.DOMoveY(transform.position.y, _durationStep));
        sequence.SetLoops(-1, LoopType.Restart);
    }
}