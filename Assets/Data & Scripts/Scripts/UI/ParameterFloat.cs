using System;

public class ParameterFloat : IReadOnlyParameterFloat
{
    private float _value;

    public ParameterFloat(float defalaulValue)
    {
        _value = defalaulValue;
    }

    public float Value
    {
        get => _value;
        private set
        {
            _value = value;
            Changed?.Invoke(value);
        }
    }

    public event Action<float> Changed;

    public void Set(float value)
    {
        Value = value < 0 ? 0 : value;
    }

    public void Add(float value)
    {
        if (Value < -value)
            Value = 0;
        else
            Value += value;
    }
}