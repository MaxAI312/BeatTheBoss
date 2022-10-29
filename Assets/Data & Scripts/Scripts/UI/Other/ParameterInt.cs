using System;

public class ParameterInt : IReadOnlyParameterInt
{
    private int _value;

    public ParameterInt(int defalaulValue)
    {
        _value = defalaulValue;
    }

    public int Value
    {
        get => _value;
        private set
        {
            _value = value;
            Changed?.Invoke(value);
        }
    }

    public event Action<int> Changed;

    public void Set(int value)
    {
        Value = value < 0 ? 0 : value;
    }

    public void Add(int value)
    {
        if (Value < -value)
            Value = 0;
        else
            Value += value;
    }
}