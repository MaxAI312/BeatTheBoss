using System;
using UnityEngine;

public class UIWidgetRageCounter : MonoBehaviour
{
    [SerializeField] private UIText _uIText;

    private ParameterInt _rageParameter;

    private void Awake()
    {
        Hide();
    }

    private void OnEnable()
    {
        if (_rageParameter == null)
            throw new NullReferenceException(nameof(_rageParameter) + " must be initialized before enable.");

        _rageParameter.Changed += OnRageChanged;
        OnRageChanged(_rageParameter.Value);
    }

    private void OnDisable()
    {
        if (_rageParameter != null)
            _rageParameter.Changed -= OnRageChanged;
    }

    public void Initialize(ParameterInt rageParameter)
    {
        _rageParameter = rageParameter;
    }

    private void OnRageChanged(int value)
    {
        _uIText.SetText(value.ToString());
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}