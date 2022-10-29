using UnityEngine;

public class KeyboardExplosion : Explosion
{
    [SerializeField] private KeycupExplosion _keycupExplosion;

    public override void Explode()
    {
        _keycupExplosion.CreateExplosion();
        base.Explode();
    }
}
