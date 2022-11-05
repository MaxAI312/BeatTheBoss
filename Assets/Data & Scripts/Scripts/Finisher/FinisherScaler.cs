using UnityEngine;
using DG.Tweening;

public class FinisherScaler : MonoBehaviour
{
    [SerializeField] private float _startValueScaling;
    [SerializeField] private float _scalingStepSize;

    private IReadOnlyParameterInt _parameter;
    private TappingBarIncome _tappingBarIncome;
    private float _startValue;
    private Scaler _scaler;

    private void OnEnable()
    {
        _tappingBarIncome.Tapped += OnTapped;
    }

    private void OnDisable()
    {
        _tappingBarIncome.Tapped -= OnTapped;
    }

    public void Initilization(IReadOnlyParameterInt parameter, TappingBarIncome tappingBarIncome, Scaler scaler)
    {
        _parameter = parameter;
        _startValue = parameter.Value;
        _tappingBarIncome = tappingBarIncome;
        _scaler = scaler;
    }

    private void OnTapped(int stepSize)
    {
        if (_startValue + stepSize < _parameter.Value)
        {
            _startValueScaling += _scalingStepSize;
            _scaler.Scale(true, _startValueScaling);

            _startValue += stepSize;
        }
    }

    public void Enable()
    {
        enabled = true;
    }

    public void Disable()
    {
        enabled = false;
    }
}
