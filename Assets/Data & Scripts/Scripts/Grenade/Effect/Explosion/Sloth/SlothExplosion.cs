using UnityEngine;

public class SlothExplosion : Explosion
{
    [SerializeField] private Rigidbody _rigidbody;

    private float _forceMultiplier = 20f;
    private float _forceMultiplierX = 3f;
    private float _forceMultiplierZ = 3f;
    private int _minRandomIndex = 0;
    private int _maxRandomIndex = 3;
    
    public override void Explode()
    {
        ExplosionParticle.Play();

        Parts.gameObject.SetActive(true);
        DisableKinematic();

        MeshRenderer.enabled = false;
        _rigidbody.AddForce(Vector3.up * _forceMultiplier, ForceMode.VelocityChange);

        int randomIndex = Random.RandomRange(_minRandomIndex, _maxRandomIndex);

        if (randomIndex == 0)
            _rigidbody.AddForce(Vector3.right * _forceMultiplierX, ForceMode.VelocityChange);
        
        else if (randomIndex == 1)
            _rigidbody.AddForce(-Vector3.right * _forceMultiplierX, ForceMode.VelocityChange);
        
        else if (randomIndex == 2)
            _rigidbody.AddForce(Vector3.forward * _forceMultiplierZ, ForceMode.VelocityChange);
        
        else if (randomIndex == 3)
            _rigidbody.AddForce(-Vector3.forward * _forceMultiplierZ, ForceMode.VelocityChange);
    }
}