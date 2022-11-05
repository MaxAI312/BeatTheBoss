using UnityEngine;

public class WaterParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    public void PlayParticleWater()
    {
        _particleSystem.Play();
    }
}
