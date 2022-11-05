using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class WeaponCardContainer : MonoBehaviour
{
    [Header("Links")] [SerializeField] private Image _icon;

    [SerializeField] private TMP_Text _labelText;
    [SerializeField] private RectTransform _rect;

    [Header("Animation params")] [SerializeField]
    private float _animateTime = 0.3f;

    [SerializeField] private float _delayToPresent = 0.3f;

    private float _scalingHideMultiplier = 0.7f;
    private float _scalingShowMultiplier = 1.3f;
    private float _targetAnchorPosX = 0f;
    private Button _button;
    private FinisherWeaponData _data;

    public bool IsClicked { get; private set; }

    private void Awake()
    {
        _button = GetComponent<Button>();
        IsClicked = false;
    }

    private void OnEnable()
    {
        _button.onClick?.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick?.RemoveListener(OnClick);
    }

    public event Action<WeaponCardContainer> PickedStart;
    public event Action<FinisherWeaponData> PickedEnd;

    public void InitCard(FinisherWeaponData data)
    {
        _data = data;
        _icon.sprite = data.Icon;
        _labelText.text = data.Label;
    }

    public void ShowHide()
    {
        _rect.DOAnchorPosX(_targetAnchorPosX, _animateTime).SetEase(Ease.InOutBack);
        _rect.DOScale(Vector3.one * _scalingHideMultiplier, _animateTime);
    }

    private void OnClick()
    {
        IsClicked = true;
        transform.SetAsLastSibling();
        StartCoroutine(ShowPick());
    }

    private IEnumerator ShowPick()
    {
        PickedStart?.Invoke(this);

        _rect.DOAnchorPosX(_targetAnchorPosX, _animateTime).SetEase(Ease.InOutBack);
        _rect.DOScale(Vector3.one * _scalingShowMultiplier, _animateTime);

        yield return new WaitForSeconds(_animateTime + _delayToPresent);

        PickedEnd?.Invoke(_data);
    }
}