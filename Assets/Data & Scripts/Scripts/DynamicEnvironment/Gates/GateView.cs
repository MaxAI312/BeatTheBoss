using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GateView : MonoBehaviour
{
    [SerializeField] private WeaponView _currentWeaponView;
    [SerializeField] private ParticleSystem _particleSystem;
    
    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        
        if (_currentWeaponView == null)
            throw new NullReferenceException(
                "_currentWeaponView is null. Сюда нужно положить текущее отображаемое оружие.");
    }

    public void ShowDisappear()
    {
        _collider.enabled = false;
        _currentWeaponView.ShowDecrease();
        PlayGateOff();
    }

    private void PlayGateOff()
    {
        _particleSystem.gameObject.SetActive(false);
    }
}