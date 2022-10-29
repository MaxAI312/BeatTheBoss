using System;

public interface IReadOnlyParameterFloat
{
    public float Value { get; }
    public event Action<float> Changed;
}