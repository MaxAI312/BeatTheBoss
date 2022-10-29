using UnityEngine;
using DG.Tweening;

public class Keyboard : MonoBehaviour
{
    [SerializeField] private float _durationDecreaseComponent = 0.10f;
    [SerializeField] private float _durationIncreaseComponent = 0.2f;
    [SerializeField] private float _maxValueScale = 2.5f;
    [SerializeField] private float _minValueScale = 1f;
    [SerializeField] private StartingKeycup _startingKeycup;

    private void OnEnable()
    {
        Scaling();
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Scaling()
    {
        var sequence = DOTween.Sequence();

        sequence.AppendInterval(1f);
        sequence.Append(transform.DOScale(_maxValueScale, _durationIncreaseComponent));
        sequence.AppendCallback(() => _startingKeycup.PushByLocalY());
        sequence.AppendCallback(() => _startingKeycup.MakePhysics());

        sequence.Append(transform.DOScale(_minValueScale, _durationDecreaseComponent));
        sequence.Append(transform.DOScale(1.25f, _durationDecreaseComponent));
        sequence.Append(transform.DOScale(1.125f, _durationDecreaseComponent));
        sequence.Append(transform.DOScale(1.2f, _durationDecreaseComponent));

    }
}
