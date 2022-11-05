using System.Collections;
using RunnerMovementSystem;
using RunnerMovementSystem.Examples;
using UnityEngine;

public sealed class Player : PlayerBase
{
    [SerializeField] private MouseInput _mouseInput;
    [SerializeField] private MovementSystem _movementSystem;
    [SerializeField] private GrenadeThrower _grenadeThrower;
    [SerializeField] private GateTimer _gateTimer;
    [SerializeField] private FinishTappingTimer _finishTappingTimer;
    [SerializeField] private RageChecker _rageChecker;
    [SerializeField] private TeapotController _teapotController;
    
    private Coroutine _guardTakenCoroutine;
    private float _speedMultiplier = 2.5f;
    private float _durationRebound = 0.2f;

    public MouseInput MouseInput => _mouseInput;
    public GrenadeThrower GrenadeThrower => _grenadeThrower;
    public GateTimer GateTimer => _gateTimer;
    public FinishTappingTimer FinishTappigTimer => _finishTappingTimer;
    public RageChecker RageChecker => _rageChecker;
    public TeapotController TeapotController => _teapotController;

    private void Update()
    {
        PlayerAnimator.SetTurn(_mouseInput.TurnValue);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        CollisionHandler.GateTaken += OnGateTaken;
        CollisionHandler.ItemGuardTaken += OnGuardTaken;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        CollisionHandler.GateTaken -= OnGateTaken;
        CollisionHandler.ItemGuardTaken -= OnGuardTaken;
    }

    private void OnGateTaken(Grenade grenade)
    {
        _grenadeThrower.SpawnGrenade(grenade);
    }

    public void StartMove()
    {
        _mouseInput.enabled = true;
        _movementSystem.enabled = true;
    }

    public void StopMove()
    {
        _mouseInput.enabled = false;
        _movementSystem.enabled = false;
    }

    private void OnGuardTaken(ItemGuard itemGuard)
    {
        if (Rage.Value < itemGuard.RageValue)
        {
            if (_guardTakenCoroutine != null) StopCoroutine(_guardTakenCoroutine);
            _guardTakenCoroutine = StartCoroutine(ReboundShowing());
        }
    }

    private IEnumerator ReboundShowing()
    {
        var defaultSpeed = _movementSystem.DefaultSpeed;

        PlayerAnimator.ShowKnockedOut();
        _movementSystem.SetSpeed(-defaultSpeed * _speedMultiplier);

        yield return new WaitForSeconds(_durationRebound);

        _movementSystem.SetSpeed(defaultSpeed);
        PlayerAnimator.ShowRun();
    }
}