using UnityEngine;

public class CupExplosion : Explosion
{
    [SerializeField] private Rigidbody _rigidbody;

    public override void Start() { }

    public override void Explode()
    {
        ExplosionParticle.Play();

        Parts.gameObject.SetActive(true);
        DisableKinematic();

        MeshRenderer.enabled = false;
    }
}
