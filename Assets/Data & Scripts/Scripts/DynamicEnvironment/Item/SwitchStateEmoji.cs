using UnityEngine;

public class SwitchStateEmoji : MonoBehaviour
{
    [SerializeField] private ParticleSystem _firstParticleEmoji;
    [SerializeField] private ParticleSystem _secondParticleEmoji;

    public void SwitchState()
    {
        _firstParticleEmoji.gameObject.SetActive(false);
        _secondParticleEmoji.Play();
    }
}
