using System;
using UnityEngine;

public abstract class MainTimer : MonoBehaviour
{
    [SerializeField] private float _timerDefaultValue;

    private ParameterFloat _seconds;

    public IReadOnlyParameterFloat Seconds => _seconds;

    private void Awake()
    {
        _seconds = new ParameterFloat(_timerDefaultValue);
        Disable();
    }

    private void Update()
    {
        _seconds.Add(-Time.deltaTime);
        if (Seconds.Value <= 0)
        {
            TimeIsOver?.Invoke();
            Disable();
        }
    }

    public event Action TimeIsOver;

    public void Enable()
    {
        enabled = true;
        _seconds.Set(_timerDefaultValue);
    }

    public void Disable()
    {
        enabled = false;
    }
}
