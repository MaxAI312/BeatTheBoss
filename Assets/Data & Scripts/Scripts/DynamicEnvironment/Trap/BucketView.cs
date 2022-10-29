using UnityEngine;

public class BucketView : TrapView
{
    [SerializeField] private ParticleSystem _particleSystem;

    public override void DestroyTrap()
    {
        base.DestroyTrap();
        _particleSystem.Play();
    }
}
