using UnityEngine;
using DG.Tweening;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _durationDecreaseComponent = 0.10f;
    [SerializeField] private float _durationIncreaseComponent = 0.2f;
    [SerializeField] private float _maxValueScaling = 2.5f;
    [SerializeField] private float _minValueScaling = 1f;

    [SerializeField] private float _isingFirstStep;
    [SerializeField] private float _isingSecondStep;
    [SerializeField] private float _isingThirdStep;
    [SerializeField] private float _isingFourthStep;

    [SerializeField] private float _maxValueWeakScaling = 1.3f;
    [SerializeField] private float _durationWeakDecreaseComponent = 0.05f;
    [SerializeField] private float _durationWeakIncreaseComponent = 0.2f;
    [SerializeField] private float _minValueWeakScaling = 1.6f;

    private float _waitingBeforeScaling = 0.55f;

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Scale(bool isWeak, float maxValueScaling = 2.5f)
    {
        var sequence = DOTween.Sequence();
        
        if (isWeak)
        {
            float isingFirstStep = maxValueScaling * 0.75f;
            float isingSecondStep = isingFirstStep - (isingFirstStep / 10);
            float isingThirdStep = isingSecondStep + ((isingFirstStep / 10) * 0.75f);

            maxValueScaling *= 0.5f;

            sequence.Append(transform.DOScale(maxValueScaling, _durationWeakIncreaseComponent));
            sequence.Append(transform.DOScale(_minValueScaling, _durationWeakDecreaseComponent));
            sequence.Append(transform.DOScale(isingFirstStep, _durationWeakDecreaseComponent));
            sequence.Append(transform.DOScale(isingSecondStep, _durationDecreaseComponent));
            sequence.Append(transform.DOScale(isingThirdStep, _durationDecreaseComponent));
        }
        else
        {
            sequence.AppendInterval(_waitingBeforeScaling);

            sequence.Append(transform.DOScale(maxValueScaling, _durationIncreaseComponent));
            sequence.Append(transform.DOScale(_isingFirstStep, _durationDecreaseComponent));
            sequence.Append(transform.DOScale(_isingSecondStep, _durationDecreaseComponent));
            sequence.Append(transform.DOScale(_isingThirdStep, _durationDecreaseComponent));
            sequence.Append(transform.DOScale(_isingFourthStep, _durationDecreaseComponent));
        }
    }
}
