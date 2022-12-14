using System.Collections.Generic;
using RunnerMovementSystem;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private BossAnimator _bossAnimator;
    [SerializeField] private BossBeatenView _bossBeatenView;
    [SerializeField] private BossInput _bossInput;
    [SerializeField] private MovementSystem _movementSystem;
    [SerializeField] private Ragdoll _ragdoll;
    [SerializeField] private Arrow _arrow;
    [SerializeField] private FinisherMover _finisherMover;
    [SerializeField] private BossCollisionHandler _bossCollisionHandler;
    [SerializeField] private HeadCollider _headCollider;
    [SerializeField] private ParticleSystem _finisherParticleSystem;
    [SerializeField] [Min(0)] private float _takenDamage;
    [SerializeField] private BossOpeningParticle _bossOpeningParticle;

    private float _defaultSpeed;
    private IReadOnlyParameterInt _playerRage;

    public Arrow Arrow => _arrow;
    public BossAnimator BossAnimator => _bossAnimator;
    public BossBeatenView BossBeatenView => _bossBeatenView;
    public BossCollisionHandler CollisionHandler => _bossCollisionHandler;
    public FinisherMover FinisherMover => _finisherMover;
    public Transform GrenadeTargetPoint => _ragdoll.GrenadeTargetPoint;
    public HeadCollider HeadCollider => _headCollider;
    public float TakenDamage => _takenDamage;
    public float Speed => _movementSystem.DefaultSpeed;
    public float MultiplierValue { get; private set; }
    public BossOpeningParticle BossOpeningParticle => _bossOpeningParticle;

    private void Awake()
    {
        _defaultSpeed = _movementSystem.DefaultSpeed;
        MultiplierValue = 0;
        _ragdoll.Initialize(_bossAnimator);
    }

    private void OnEnable()
    {
        _bossCollisionHandler.StopperTaken += OnStopperTaken;
        _bossCollisionHandler.GrenadeTaken += OnGrenadeTaken;
        _bossCollisionHandler.WallTaken += OnWallTaken;
        _movementSystem.RoadEndReached += OnRoadEndReached;
    }

    private void OnDisable()
    {
        _bossCollisionHandler.StopperTaken -= OnStopperTaken;
        _bossCollisionHandler.GrenadeTaken -= OnGrenadeTaken;
        _bossCollisionHandler.WallTaken -= OnWallTaken;
        _movementSystem.RoadEndReached -= OnRoadEndReached;
    }

    public void Initialize(IReadOnlyList<Wall> walls, IReadOnlyParameterInt playerRage)
    {
        _finisherMover.Initialize(transform, _ragdoll, walls);
        _playerRage = playerRage;
    }

    public void StartMove()
    {
        _bossInput.Enable();
        _movementSystem.enabled = true;
    }

    public void StopMove()
    {
        _bossInput.Disable();
        _movementSystem.enabled = false;
    }

    public void SetTimeScale(float value)
    {
        _movementSystem.SetSpeed(_defaultSpeed * value);
        _bossAnimator.SetTimeScale(value);
    }

    public void PlayFinisherParticles()
    {
        _finisherParticleSystem.Play();
    }

    private void OnStopperTaken()
    {
        StopMove();
        _bossAnimator.ShowIdle();
    }

    private void OnRoadEndReached()
    {
        StopMove();
        _bossAnimator.ShowFinisher();
    }

    private void OnGrenadeTaken(Grenade grenade)
    {
        _takenDamage += grenade.DamageValue;
        _bossBeatenView.SetHitted(_takenDamage);
        _bossAnimator.ShowHitToBody();
        grenade.Destroy();
    }

    private void OnWallTaken(Wall wall)
    {
        _bossAnimator.ShowWallHit();
        MultiplierValue = wall.MultiplierValue;
    }
}