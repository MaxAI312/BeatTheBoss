using UnityEngine;

public class PlayerOpeningParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _firstParticle;
    [SerializeField] private ParticleSystem _secondParticle;

    public void PlaySecondParticle()
    {
        _firstParticle.gameObject.SetActive(false);
        _secondParticle.Play();
    }
}
