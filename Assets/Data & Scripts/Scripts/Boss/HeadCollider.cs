using UnityEngine;

public class HeadCollider : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _headShotParticles;

    private void OnTriggerEnter(Collider other)
    {
        if(_headShotParticles.Length == 0)
            return;
        
        var grenade = other.GetComponent<Grenade>();
        if (grenade)
        {
            var index = Random.Range(0, _headShotParticles.Length);
            _headShotParticles[index].Play();
        }
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}