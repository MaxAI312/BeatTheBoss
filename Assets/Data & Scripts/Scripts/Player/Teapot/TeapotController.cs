using UnityEngine;
using DG.Tweening;
using System;

public class TeapotController : MonoBehaviour
{
    private const string Blend = nameof(Blend);
    
    [SerializeField] private ParticleSystem _firstParticleSystem;
    [SerializeField] private ParticleSystem _secondParticleSystem;
    [SerializeField] private Teapot _teapot;
    [SerializeField] private Player _player;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Animator _animator;

    private MeshRenderer _meshRenderer;
    private int _minEmissionValue = 1;
    private int _maxEmissionValue = 45;
    private int _currentEmissionCount;
    private float _durationAfterEffect = 0.2f;
    private int _indexConvertMaterial = 1;

    private void Awake()
    {
        _currentEmissionCount = _minEmissionValue;
        _meshRenderer = _teapot.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        ChangeEmissionCount();
        ConvertColor();
        BlendAnimation();
    }

    private void ChangeEmissionCount()
    {
        var rateOverTime = _firstParticleSystem.emission.rateOverTime.constant;
        rateOverTime = GetConvertedToInt();
        _firstParticleSystem.emissionRate = rateOverTime;
    }

    private int GetConvertedToInt()
    {
        float normalizeRageValue = (float)_player.Rage.Value / _player.PlayerConfig.MaxRage;
        float normalizeEmissionValue = Mathf.Round((normalizeRageValue / ((float)_minEmissionValue / _maxEmissionValue)));
        _currentEmissionCount = Convert.ToInt32(normalizeEmissionValue);

        return _currentEmissionCount;
    }

    private void ConvertColor()
    {
        float normalizeRageValue = (float)_player.Rage.Value / _player.PlayerConfig.MaxRage;

        _meshRenderer.materials[_indexConvertMaterial].color = _gradient.Evaluate(normalizeRageValue);
    }

    private void BlendAnimation()
    {
        float normalizeRageValue = (float)_player.Rage.Value / _player.PlayerConfig.MaxRage;
        _animator.SetFloat(Blend, normalizeRageValue);
    }

    private void PlayFirstParticle()
    {
        _firstParticleSystem.Play();
    }

    public void PlaySecondParticle()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendCallback(() => _secondParticleSystem.Play());
        sequence.AppendInterval(_durationAfterEffect);
        _firstParticleSystem.gameObject.SetActive(false);
    }
}
