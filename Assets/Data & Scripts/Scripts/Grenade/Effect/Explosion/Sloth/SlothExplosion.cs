using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothExplosion : Explosion
{
    [SerializeField] private Rigidbody _rigidbody;

    public override void Explode()
    {
        ExplosionParticle.Play();

        Parts.gameObject.SetActive(true);
        DisableKinematic();

        MeshRenderer.enabled = false;
        _rigidbody.AddForce(Vector3.up * 20f, ForceMode.VelocityChange);

        int randomIndex = Random.RandomRange(0, 3);

        if (randomIndex == 0)
        {
            _rigidbody.AddForce(Vector3.right * 3f, ForceMode.VelocityChange);//Refactoring
        }
        else if (randomIndex == 1)
        {
            _rigidbody.AddForce(Vector3.right * -3f, ForceMode.VelocityChange);
        }
        else if (randomIndex == 2)
        {
            _rigidbody.AddForce(Vector3.right * 3f, ForceMode.VelocityChange);
        }
        else if (randomIndex == 3)
        {
            _rigidbody.AddForce(Vector3.right * -3f, ForceMode.VelocityChange);
        }
    }
}
