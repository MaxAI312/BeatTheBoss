using UnityEngine;
using DG.Tweening;

public class Recorder : MonoBehaviour
{
    [SerializeField] private bool _isRecord = false;

    private void OnEnable()
    {
        PlayAnimation();
    }

    private void Update()
    {
        if (_isRecord)
        {
            PlayAnimation();

            _isRecord = false;
        }
    }

    private void PlayAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        Vector3 targetPullOut = new Vector3(transform.localScale.x - 0.075f, transform.localScale.y + 0.19f, transform.localScale.z); //MAGIC INT
        Vector3 targetCompress = new Vector3(transform.localScale.x + 0.15f, transform.localScale.y - 0.19f, transform.localScale.z);//MAGIC INT

        sequence.Append(transform.DOScale(targetPullOut, 0.2f));//MAGIC INT
        sequence.Append(transform.DOScale(transform.localScale, 0.1f));//MAGIC INT

        sequence.Append(transform.DOScale(targetCompress, 0.2f));//MAGIC INT
        sequence.Append(transform.DOScale(transform.localScale, 0.1f));//MAGIC INT

        sequence.SetLoops(-1, LoopType.Restart);
    }
}
