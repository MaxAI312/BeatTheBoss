using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class WeaponHolder : MonoBehaviour
{
    private Player _player;
    private List<WeaponData> _weaponData;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _weaponData = new List<WeaponData>();
    }

    private void Update()
    {
        UpdateWeapons();
    }

    private void UpdateWeapons()
    {
        if (_weaponData.Count <= 0)
            return;

        foreach (var ability in _weaponData)
        {
            ability.Update();
        }
    }

    public void AddWeapon(WeaponData data)
    {
        if (_weaponData.Contains(data) == false)
        {
            Debug.Log(data.WeaponLabel);

            _weaponData.Add(data);
            data.Activate(_player);
        }
    }
}
