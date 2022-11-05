using UnityEngine;
using DG.Tweening;

public class Recorder : MonoBehaviour
{
    private float _negativeScalingValueX = -0.075f;
    private float _positiveScalingValueX = 0.15f;
    private float _negativeScalingValueY = -0.19f;
    private float _positiveScalingValueY = 0.19f;
    private float _durationPullOut = 0.2f;
    private float _durationCompress = 0.2f;
    private float _durationDefaultScaling = 0.1f;
    
    private void OnEnable()
    {
        PlayAnimation();
    }

    private void PlayAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        Vector3 targetPullOut = new Vector3(transform.localScale.x + _negativeScalingValueX,
                                            transform.localScale.y + _positiveScalingValueY,
                                              transform.localScale.z);
        
        Vector3 targetCompress = new Vector3(transform.localScale.x + _positiveScalingValueX,
                                             transform.localScale.y + _negativeScalingValueY,
                                               transform.localScale.z);

        sequence.Append(transform.DOScale(targetPullOut, _durationPullOut));
        sequence.Append(transform.DOScale(transform.localScale, _durationDefaultScaling));

        sequence.Append(transform.DOScale(targetCompress, _durationCompress));
        sequence.Append(transform.DOScale(transform.localScale, _durationDefaultScaling));

        sequence.SetLoops(-1, LoopType.Restart);
    }
}
