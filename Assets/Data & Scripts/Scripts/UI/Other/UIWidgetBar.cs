using UnityEngine;

public class UIWidgetBar : MonoBehaviour
{
    [SerializeField] private Bar _bar;
    [SerializeField] private UIGradientImageColorChanger _colorChanger;

    private int _maxValue;
    private IReadOnlyParameterInt _parameter;

    private void OnEnable()
    {
        if (_parameter != null)
        {
            _parameter.Changed += OnParameterChanged;
            OnParameterChanged(_parameter.Value);
        }
    }

    private void OnDisable()
    {
        if (_parameter != null)
        {
            _parameter.Changed -= OnParameterChanged;
            OnParameterChanged(_parameter.Value);
        }
    }

    public void Initialize(IReadOnlyParameterInt parameter, int maxValue)
    {
        _parameter = parameter;
        _maxValue = maxValue;
    }

    protected virtual void OnParameterChanged(int value)
    {
        var normalizedValue = (float) value / _maxValue;
        _bar.SetValue(normalizedValue);
        _colorChanger.SetColorBy(normalizedValue);
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