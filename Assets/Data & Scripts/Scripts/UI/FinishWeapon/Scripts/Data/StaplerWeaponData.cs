using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Stapler", fileName = "Stapler", order = 51)]
public class StaplerWeaponData : WeaponData
{
    [SerializeField] private int _damage;

    private StaplerWeapon _weapon;

    public int Damage => _damage;
    public StaplerWeaponData() : base(WeaponLabel.Stapler) { }

    public override void Activate(Player player)
    {
        if (_weapon != null)
            return;

        _weapon = new StaplerWeapon(this, player);
    }

    public override void Dispose()
    {
        _weapon = null;
    }

    public override void Update() { }

    public class StaplerWeapon : Weapon
    {
        private Player _player;
        private StaplerWeaponData _data;

        public StaplerWeapon(StaplerWeaponData staplerWeaponData, Player player)
        {
            _player = player;
            _data = staplerWeaponData;
        }

        public override void Update() { }
    }
}
