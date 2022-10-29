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

    private float _defaultSpeed;
    private Coroutine _guardTakenCoroutine;

    public MouseInput MouseInput => _mouseInput;
    public GrenadeThrower GrenadeThrower => _grenadeThrower;
    public GateTimer GateTimer => _gateTimer;
    public FinishTappingTimer FinishTappigTimer => _finishTappingTimer;
    public RageChecker RageChecker => _rageChecker;
    public TeapotController TeapotController => _teapotController;

    protected override void Awake()
    {
        base.Awake();
        _defaultSpeed = _movementSystem.DefaultSpeed;
    }

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

    private void OnRageChanged(int rageValue)
    {
        rageValue = Mathf.Clamp(rageValue, 0, 100);//MAGIC INT
        var rageNormalized = rageValue / 100f;//MAGIC INT
        _movementSystem.SetSpeed(_defaultSpeed + _defaultSpeed * rageNormalized * 0.5f);//MAGIC INT

        var animationSpeed = Mathf.Clamp(_movementSystem.CurrentSpeed / _defaultSpeed, 0.5f, 1.5f);//MAGIC INT
        PlayerAnimator.SetTimeScale(animationSpeed);
    }

    public void SetTimeScale(float value)
    {
        _movementSystem.SetSpeed(_defaultSpeed * value);
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
        _movementSystem.SetSpeed(-defaultSpeed * 2.5f);//MAGIC INT

        yield return new WaitForSeconds(0.2f);//MAGIC INT

        _movementSystem.SetSpeed(defaultSpeed);
        PlayerAnimator.ShowRun();
    }
}