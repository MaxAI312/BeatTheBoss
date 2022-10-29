using UnityEngine;

[CreateAssetMenu(menuName = "FinisherWeapon", fileName = "New FinisherWeapon", order = 51)]
public class FinisherWeaponData : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _label;
    [SerializeField] private Grenade _grenadePrefab;

    public Sprite Icon => _icon;
    public string Label => _label;
    public Grenade GrenadePrefab => _grenadePrefab;
}