using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

[RequireComponent(typeof(CanvasGroup), typeof(WeaponChooser))]
public class FadeEffect : MonoBehaviour
{
    private WeaponChooser _weaponChooser;
    private CanvasGroup _canvasGroup;
    private bool _isPicking = false;
    private float _targetPickStartedAlpha = 1f;
    private float _targetPickEndedAlpha = 0f;
    private float _durationPickStart = 0.1f;
    private float _durationPickEnd = 0.5f;

    private void Awake()
    {
        _weaponChooser = GetComponent<WeaponChooser>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    private void OnEnable()
    {
        _weaponChooser.PickStarted += OnPickStarted;
        _weaponChooser.PickEnded += OnPickEnded;
    }

    private void OnDisable()
    {
        _weaponChooser.PickStarted -= OnPickStarted;
        _weaponChooser.PickEnded -= OnPickEnded;
        DOTween.Complete(this);
    }

    public async void OnPickStarted()
    {
        _isPicking = true;

        do
        {
            _canvasGroup.alpha = Mathf.Lerp(_canvasGroup.alpha, _targetPickStartedAlpha, _durationPickStart);
            await Task.Yield();
        } while (_canvasGroup.alpha < 0.99f && _isPicking == true);
    }

    public void OnPickEnded(FinisherWeaponData data)
    {
        _isPicking = false;
        _canvasGroup.DOFade(_targetPickEndedAlpha, _durationPickEnd);
    }
}
