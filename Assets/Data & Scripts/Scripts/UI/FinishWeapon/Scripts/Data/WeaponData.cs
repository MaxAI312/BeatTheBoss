using UnityEngine;

public abstract class WeaponData : ScriptableObject
{
    [Header("Main properties")]
    [SerializeField] protected WeaponLabel Label;
    [SerializeField] protected Sprite Icon;
    [SerializeField] protected string Description;
    [SerializeField] private Grenade _grenadePrefab;

    private WeaponLabel _label;
    public Grenade GrenadePrefab => _grenadePrefab;
    public WeaponLabel WeaponLabel => Label;
    public Sprite WeaponIcon => Icon;
    public string WeaponDescription => Description;
    public float Points { get; protected set; }

    public WeaponData(WeaponLabel label)
    {
        Label = label;
        _label = label;
    }

    public abstract void Update();

    private void OnValidate()
    {
        if (Label != _label)
            Label = _label;
    }

    public abstract void Activate(Player player);

    public abstract void Dispose();

    public virtual float GetPoints()
    {
        return Points;
    }

    public abstract class Weapon { public abstract void Update(); }
}

public enum WeaponLabel
{
    Stapler,
    Fan,
    Monitor
}