using System.Collections;
using UnityEngine;
using DG.Tweening;

public class StaplerExplosion : Explosion
{
    [SerializeField] private float _delayBeforeExplosion = 2.6f;
    [SerializeField] private float _radius = 2f;
    [SerializeField] private GameObject[] _parts;

    private float _elapsedTime = 0;
    private Coroutine _fadeDragInJob;

    private float _durationIncreaseFading = 0.4f;
    private float _delayBeforeIncreaseFading = 0.4f;

    private float _durationDecreaseFading = 0.8f;
    private float _delayBeforeDecreaseFading = 0.8f;

    private float _targetMinDragValue = 0f;
    private float _targetMaxDragValue = 4.5f;

    public override void Start() { }

    public override void Explode()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(_delayBeforeExplosion);

        sequence.AppendCallback(() =>
        {
            ExplosionParticle.Play();
            CreateParts(_parts);

            for (int i = 0; i < _parts.Length; i++)
            {
                _parts[i].GetComponent<Rigidbody>().AddExplosionForce(ExplosionPower, transform.position, _radius);
                _parts[i].GetComponent<KeycupMover>().MoveAfterFalling();
            }
        });
    }

    private void CreateParts(GameObject[] iceCubes)
    {
        for (int i = 0; i < _parts.Length; i++)
        {
            iceCubes[i].gameObject.SetActive(true);
            iceCubes[i].GetComponent<Rigidbody>().isKinematic = false;

            InfluenceToDrag(iceCubes[i].GetComponent<Rigidbody>());
        }
    }

    private void InfluenceToDrag(Rigidbody rigidbody)
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendCallback(() =>
        {
            _fadeDragInJob = StartCoroutine(FadeDrag(rigidbody, _durationIncreaseFading, _targetMaxDragValue));
        });

        sequence.AppendInterval(_delayBeforeIncreaseFading);
        sequence.AppendCallback(() =>
        {
            StopCoroutine(_fadeDragInJob);
        });

        sequence.AppendInterval(_delayBeforeIncreaseFading);
        sequence.AppendCallback(() =>
        {
            _fadeDragInJob = StartCoroutine(FadeDrag(rigidbody, _durationDecreaseFading, _targetMinDragValue));
        });

        sequence.AppendInterval(_delayBeforeDecreaseFading);
        sequence.AppendCallback(() =>
        {
            StopCoroutine(_fadeDragInJob);
        });
    }

    private IEnumerator FadeDrag(Rigidbody rigidbody, float durationFading, float targetDragValue)
    {
        while (_elapsedTime < durationFading)
        {
            _elapsedTime += Time.deltaTime;
            rigidbody.drag = Mathf.Lerp(rigidbody.drag, targetDragValue, _elapsedTime / durationFading);
            yield return null;
        }
        _elapsedTime = 0f;
    }
}
