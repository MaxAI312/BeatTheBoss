using System;
using UnityEngine;

public class SlapParticle : MonoBehaviour //REFACTORING
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Collider _collider;
    [SerializeField] private UIText _text;
    [SerializeField] private SlapHandler _slapHandler;

    private int _currentIndexSlap;

    public event Action Slaped;

    private void OnEnable()
    {
        _slapHandler.IndexSlapChanged += OnIndexSlapChanged;
    }

    private void OnDisable()
    {
        _slapHandler.IndexSlapChanged -= OnIndexSlapChanged;
    }

    private void OnIndexSlapChanged(int indexSlap)
    {
        _currentIndexSlap = indexSlap;

    }

    private void OnCollisionEnter(Collision collision)
    {
        var ReactionsSwitcher = collision.gameObject.GetComponentInParent<ReactionsSwitcher>();

        if (ReactionsSwitcher)
        {
            ReactionsSwitcher.OnSlaped(_currentIndexSlap);

            _particleSystem.Play();
            _text.PlayAnimation();
            DisableCollider();
        }
    }

    public void EnableCollider()
    {
        _collider.enabled = true;
    }

    public void DisableCollider()
    {
        _collider.enabled = false;
    }
}
