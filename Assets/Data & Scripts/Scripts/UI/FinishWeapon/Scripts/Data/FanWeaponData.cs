using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Fan", fileName = "Fan", order = 51)]
public class FanWeaponData : WeaponData
{
    [SerializeField] private int _damage;

    private FanWeapon _weapon;

    public int Damage => _damage;
    public FanWeaponData() : base(WeaponLabel.Fan) { }

    public override void Activate(Player player)
    {
        if (_weapon != null)
            return;

        _weapon = new FanWeapon(this, player);
    }

    public override void Dispose()
    {
        _weapon = null;
    }

    public override void Update() { }

    public class FanWeapon : Weapon
    {
        private Player _player;
        private FanWeaponData _data;

        public FanWeapon(FanWeaponData fanWeaponData, Player player)
        {
            _player = player;
            _data = fanWeaponData;
        }

        public override void Update() { }
    }
}