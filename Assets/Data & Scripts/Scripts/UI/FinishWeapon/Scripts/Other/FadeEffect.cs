using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

[RequireComponent(typeof(CanvasGroup), typeof(WeaponChooser))]
public class FadeEffect : MonoBehaviour
{
    private WeaponChooser _weaponChooser;
    private CanvasGroup _canvasGroup;
    private bool _isPicking = false;

    private void Awake()
    {
        _weaponChooser = GetComponent<WeaponChooser>();
        _canvasGroup = GetComponent<CanvasGroup>();
        //_canvasGroup.DOFade(0, 0);
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
            _canvasGroup.alpha = Mathf.Lerp(_canvasGroup.alpha, 1, 0.1f);//MAGIC INT
            await Task.Yield();
        } while (_canvasGroup.alpha < 0.99f && _isPicking == true);//MAGIC INT
    }

    public void OnPickEnded(FinisherWeaponData data)
    {
        _isPicking = false;
        _canvasGroup.DOFade(0, 0.5f);//MAGIC INT
    }
}
