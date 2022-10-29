using UnityEngine;

public class UIWidgetTimerBar : MonoBehaviour
{
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private UIGradientImageColorChanger _colorChanger;

    private float _maxValue;
    private IReadOnlyParameterFloat _parameter;

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

    public void Initialize(IReadOnlyParameterFloat parameter, float maxValue)
    {
        _parameter = parameter;
        _maxValue = maxValue;
    }

    private void OnParameterChanged(float value)
    {
        var normalizedValue = value / _maxValue;
        _progressBar.SetValue(normalizedValue);
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