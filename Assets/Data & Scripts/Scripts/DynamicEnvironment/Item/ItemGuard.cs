using System;
using RootMotion.Dynamics;
using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(Collider))]
public class ItemGuard : MonoBehaviour
{
    private const string PushPlayer = nameof(PushPlayer);
    
    [SerializeField] private UIWidgetForceView _uIWidgetForceView;
    [SerializeField] private PuppetMaster _puppetMaster;
    [SerializeField] private Animator _animator;
    [SerializeField] [Min(0)] private int _rageValue;
    [SerializeField] private Color _greaterColor;
    [SerializeField] private Color _smallerColor;

    private Collider _collider;
    private Player _player;

    public int RageValue => _rageValue;

    private void Start()
    {
        _uIWidgetForceView.SetText(_rageValue.ToString());
        _player = FindObjectOfType<Player>();
        _collider = GetComponent<Collider>();
        OnRageChanged(_player.Rage.Value);
        _player.Rage.Changed += OnRageChanged;

        if (_player == null)
            throw new NullReferenceException(typeof(Player) + " is null.");
    }

    public void Disable()
    {
        _collider.enabled = false;
        _uIWidgetForceView.Hide();
        _player.Rage.Changed -= OnRageChanged;
    }

    public void ShowPush()
    {
        _puppetMaster.enabled = false;
        _animator.enabled = true;
        _animator.SetTrigger(PushPlayer);
    }

    private void OnRageChanged(int value)
    {
        _uIWidgetForceView.SetTextColor(value >= _rageValue ? _smallerColor : _greaterColor);
    }
}