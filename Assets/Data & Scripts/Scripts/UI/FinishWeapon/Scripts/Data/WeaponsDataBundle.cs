using UnityEngine;

[CreateAssetMenu(fileName = "New Weapons Bundle", menuName = "Weapons Bundle", order = 51)]
public class WeaponsDataBundle : ScriptableObject
{
    [SerializeField] private WeaponData[] _weaponsData;

    public int WeaponCount => _weaponsData.Length;
    public WeaponData this[int index]
    {
        get { return _weaponsData[index]; }
        set { _weaponsData[index] = value; }
    }
}
