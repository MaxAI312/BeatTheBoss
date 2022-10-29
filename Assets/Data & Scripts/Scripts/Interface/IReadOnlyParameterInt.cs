using System;

public interface IReadOnlyParameterInt
{
    public int Value { get; }
    public event Action<int> Changed;
}