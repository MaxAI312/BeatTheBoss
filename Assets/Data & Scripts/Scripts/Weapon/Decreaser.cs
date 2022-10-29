using UnityEngine;
using DG.Tweening;

public class Decreaser : MonoBehaviour
{
    [SerializeField] private float _durationDecreaseComponent = 0.10f;
    [SerializeField] private float _durationIncreaseComponent = 0.2f;
    [SerializeField] private float _maxValueScale = 2.5f;
    [SerializeField] private float _minValueScale = 1f;

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Decrease()
    {
        var sequence = DOTween.Sequence();

        sequence.Append(transform.DOScale(_maxValueScale, _durationIncreaseComponent));
        sequence.Append(transform.DOScale(_minValueScale, _durationDecreaseComponent));
    }
}
