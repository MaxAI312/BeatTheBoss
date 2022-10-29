using System;
using UnityEngine;

public abstract class BarLoss : MonoBehaviour
{
    [SerializeField][Min(0)] protected int Value;
    [SerializeField][Min(0)] protected float Seconds;

    private float _timer;

    public event Action<int> Ticked;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > Seconds)
        {
            Ticked?.Invoke(Value);
            _timer -= Seconds;
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
