using UnityEngine;

public class GuitarExplosion : Explosion
{
    [SerializeField] private KeycupExplosion _keycupExplosion;

    public override void Explode()
    {
        _keycupExplosion.CreateExplosion();
        base.Explode();
    }
}
