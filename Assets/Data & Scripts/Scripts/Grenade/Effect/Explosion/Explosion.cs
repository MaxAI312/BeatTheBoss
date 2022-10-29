using UnityEngine;

public abstract class Explosion : MonoBehaviour
{
    [SerializeField] protected float ExplosionPower;
    [SerializeField] protected Transform Parts;
    [SerializeField] protected ParticleSystem ExplosionParticle;

    private Rigidbody[] _rigidbodies;

    protected bool IsExplosed;//refactoring
    protected MeshRenderer MeshRenderer;

    public virtual void Awake()
    {
        MeshRenderer = GetComponent<MeshRenderer>();

        _rigidbodies = Parts.GetComponentsInChildren<Rigidbody>();
    }

    public virtual void Start()
    {
        Parts.gameObject.SetActive(false);
    }

    public virtual void Explode()
    {
        if (IsExplosed)
            return;

        IsExplosed = true;
        ExplosionParticle.Play();

        Vector3 origin = GetAveragePosition();

        Parts.gameObject.SetActive(true);

        MeshRenderer.enabled = false;

        foreach (var rigidbody in _rigidbodies)
        {
            Vector3 force = (rigidbody.transform.position - origin).normalized * ExplosionPower;

            rigidbody.isKinematic = false;
            rigidbody.AddForce(force, ForceMode.VelocityChange);
        }
    }

    protected void DisableKinematic()
    {
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = false;
        }
    }

    private Vector3 GetAveragePosition()
    {
        Vector3 position = Vector3.zero;

        foreach (var rigidbody in _rigidbodies)
            position += rigidbody.transform.position;

        position /= _rigidbodies.Length;

        return position;
    }
}
