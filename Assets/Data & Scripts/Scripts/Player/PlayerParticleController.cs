using UnityEngine;
using DG.Tweening;

public class PlayerParticleController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _itemTrailParticle;

    private float _durationPlayingParticle = 0.2f;

    public void PlayItemTrailParticle()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendCallback(() => _itemTrailParticle.Play());
        sequence.AppendInterval(_durationPlayingParticle);
        sequence.AppendCallback(() => _itemTrailParticle.Stop());
    }
}
