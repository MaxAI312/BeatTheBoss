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
    [SerializeField] private SlapParticle[] _slapParticles;
    [SerializeField] private AnimationCurve _openingRageAnimationCurve;
    [SerializeField] [Min(0.001f)] private float _rageAnimatinDuration;
    [SerializeField] [Min(0)] private float _moddleHitDelta;
    [SerializeField] private PlayerOpeningParticle _playerOpeningParticle;

    private ParameterInt _rage;

    public PlayerCollisionHandler CollisionHandler => _playerCollisionHandler;
    public UIWidgetRageBar UIWidgetRageBar => _rageBar;
    public UIWidgetRageCounter UIWidgetRageCounter => _rageCounter;
    public PlayerAnimator PlayerAnimator => _playerAnimator;
    public RageLoss RageLoss => _rageLoss;
    public IReadOnlyParameterInt Rage => _rage;
    public PlayerConfig PlayerConfig => _playerConfig;
    public SlapParticle[] SlapParticles => _slapParticles; //может быть нужен интерфейс на чтение?
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
            _playerAnimator.ShowRightHandSlapBy(Random.Range(0, 5));//MAGIC INT
        else if (itemRelativePos.x < -_moddleHitDelta)
            _playerAnimator.ShowLeftHandSlapBy(Random.Range(0, 5));//MAGIC INT
        else
            _playerAnimator.ShowMiddleSlapBy(Random.Range(0, 5));//MAGIC INT

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

    private void OnTicked(int value)
    {
        _rage.Add(-value);
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
                _playerAnimator.ShowRightHandSlapBy(Random.Range(0, 5));//MAGIC INT
            else if (itemRelativePos.x < -_moddleHitDelta)
                _playerAnimator.ShowLeftHandSlapBy(Random.Range(0, 5));//MAGIC INT
            else
                _playerAnimator.ShowMiddleSlapBy(Random.Range(0, 5));//MAGIC INT

            _rage.Add(guard.RageValue);
        }
        else
        {
            guard.ShowPush();
            _rage.Add(-guard.RageValue);
        }
    }

    public void ShowOpeningRageAnimation()
    {
        StartCoroutine(OpeningAnimationShowing());
    }

    private IEnumerator OpeningAnimationShowing()
    {
        for (float i = 0; i < 1; i += Time.deltaTime / _rageAnimatinDuration)
        {
            var value = _openingRageAnimationCurve.Evaluate(i);

            _rage.Set((int) value);

            yield return null;
        }

        _rage.Set(0);
    }
}