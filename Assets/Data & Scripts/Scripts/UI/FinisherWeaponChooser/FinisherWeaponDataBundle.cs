using UnityEngine;

[CreateAssetMenu(fileName = "Finisher Weapons Bundle", menuName = "FinisherWeaponsBundle", order = 52)]
public class FinisherWeaponDataBundle : ScriptableObject
{
    [SerializeField] private FinisherWeaponData[] _weaponDatas;

    public int WeaponCount => _weaponDatas.Length;

    public FinisherWeaponData this[int index]
    {
        get => _weaponDatas[index];
        set => _weaponDatas[index] = value;
    }
}