using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Monitor", fileName = "Monitor", order = 51)]
public class MonitorWeaponData : WeaponData
{
    [SerializeField] private int _damage;

    private MonitorWeapon _weapon;

    public int Damage => _damage;
    public MonitorWeaponData() : base(WeaponLabel.Monitor) { }

    public override void Activate(Player player)
    {
        if (_weapon != null)
            return;

        _weapon = new MonitorWeapon(this, player);
    }

    public override void Dispose()
    {
        _weapon = null;
    }

    public override void Update() { }

    public class MonitorWeapon : Weapon
    {
        private Player _player;
        private MonitorWeaponData _data;

        public MonitorWeapon(MonitorWeaponData monitorWeaponData, Player player)
        {
            _player = player;
            _data = monitorWeaponData;
        }

        public override void Update() { }
    }
}
