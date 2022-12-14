using System;
using UnityEngine;

public class RageChecker : MonoBehaviour
{
    [SerializeField] private Player _player;

    private int _startingValueRage;
    private int _dividerValueRage = 2;

    private void Awake()
    {
        Disable();
    }

    private void OnEnable()
    {
        _startingValueRage = _player.Rage.Value;
    }

    private void Update()
    {
        if (_player.Rage.Value >= (_startingValueRage + (_startingValueRage / _dividerValueRage)))
        {
            RageLimitIsOver?.Invoke();
            Disable();
        }
    }

    public event Action RageLimitIsOver;

    public void Enable()
    {
        enabled = true;
    }

    public void Disable()
    {
        enabled = false;
    }
}
