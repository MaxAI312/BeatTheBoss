using System.Collections;
using UnityEngine;

public abstract class PlayerBase : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private PlayerCollisionHandler _playerCollisionHandler;
    [SerializeField] private UIWidgetRageBar _rageBar;
    [SerializeField] private UIWidgetRageCounter _rageCounter;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private RageLoss _rageLoss;
    [SerializeField] private PlayerParticleController _playerParticleController;
    [SerializeField] private SlapController[] _slapParticles;
    [SerializeField] private AnimationCurve _openingRageAnimationCurve;
    [SerializeField] [Min(0.001f)] private float _rageAnimatinDuration;
    [SerializeField] [Min(0)] private float _moddleHitDelta;
    [SerializeField] private PlayerOpeningParticle _playerOpeningParticle;

    private ParameterInt _rage;
    private int _minIndexSlapAnimation = 0;
    private int _maxIndexSlapAnimation = 5;

    public PlayerCollisionHandler CollisionHandler => _playerCollisionHandler;
    public UIWidgetRageBar UIWidgetRageBar => _rageBar;
    public UIWidgetRageCounter UIWidgetRageCounter => _rageCounter;
    public PlayerAnimator PlayerAnimator => _playerAnimator;
    public RageLoss RageLoss => _rageLoss;
    public IReadOnlyParameterInt Rage => _rage;
    public PlayerConfig PlayerConfig => _playerConfig;
    public SlapController[] SlapParticles => _slapParticles;
    public PlayerOpeningParticle PlayerOpeningParticle => _playerOpeningParticle;

    protected virtual void Awake()
    {
        _rage = new ParameterInt(_playerConfig.DefaultRage);
        _rageBar.Initialize(_rage, _playerConfig.MaxRage);
        _rageCounter.Initialize(_rage);
        _rageLoss.Disable();
    }

    protected virtual void OnEnable()
    {
        _playerCollisionHandler.ItemTaken += OnItemTaken;
        _playerCollisionHandler.TrapTaken += OnTrapTaken;
        _playerCollisionHandler.BossSlapped += OnBossSlapped;
        _playerCollisionHandler.ItemGuardTaken += OnGuardTaken;
    }

    protected virtual void OnDisable()
    {
        _playerCollisionHandler.ItemTaken -= OnItemTaken;
        _playerCollisionHandler.TrapTaken -= OnTrapTaken;
        _playerCollisionHandler.BossSlapped -= OnBossSlapped;
        _playerCollisionHandler.ItemGuardTaken -= OnGuardTaken;
    }

    public void AddRage(int value)
    {
        _rage.Add(value);
    }

    private void OnItemTaken(Item item)
    {
        var itemRelativePos = transform.InverseTransformPoint(item.transform.position);

        for (var i = 0; i < _slapParticles.Length; i++)
            _slapParticles[i].EnableCollider();

        if (itemRelativePos.x > _moddleHitDelta)
            _playerAnimator.ShowRightHandSlapBy(Random.Range(_minIndexSlapAnimation, _maxIndexSlapAnimation));
        else if (itemRelativePos.x < -_moddleHitDelta)
            _playerAnimator.ShowLeftHandSlapBy(Random.Range(_minIndexSlapAnimation, _maxIndexSlapAnimation));
        else
            _playerAnimator.ShowMiddleSlapBy(Random.Range(_minIndexSlapAnimation, _maxIndexSlapAnimation));

        _rage.Add(item.RageValue);
    }

    private void OnTrapTaken(Trap trap)
    {
        _playerAnimator.ShowStumbling();
        _rage.Add(-trap.Value);
    }

    private void OnBossSlapped()
    {
        _rage.Add(-20);//MAGIC INT
        PlayerAnimator.ShowSlap();
    }

    private void OnGuardTaken(ItemGuard guard)
    {
        guard.Disable();

        if (_rage.Value >= guard.RageValue)
        {
            var itemRelativePos = transform.InverseTransformPoint(guard.transform.position);

            for (var i = 0; i < _slapParticles.Length; i++)
                _slapParticles[i].EnableCollider();

            if (itemRelativePos.x > _moddleHitDelta)
                _playerAnimator.ShowRightHandSlapBy(Random.Range(_minIndexSlapAnimation, _maxIndexSlapAnimation));
            else if (itemRelativePos.x < -_moddleHitDelta)
                _playerAnimator.ShowLeftHandSlapBy(Random.Range(_minIndexSlapAnimation, _maxIndexSlapAnimation));
            else
                _playerAnimator.ShowMiddleSlapBy(Random.Range(_minIndexSlapAnimation, _maxIndexSlapAnimation));

            _rage.Add(guard.RageValue);
        }
        else
        {
            guard.ShowPush();
            _rage.Add(-guard.RageValue);
        }
    }
}