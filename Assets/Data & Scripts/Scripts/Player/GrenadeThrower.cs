using System;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    [SerializeField] private Grenade _grenadePrefabByDefault;
    [SerializeField] private TargetingRay _targetingRay;
    [SerializeField] private EndAnimationHandler _endAnimationHandler;

    private RayInput _rayInput;
    private Grenade _spawnedGrenade;

    private void Awake()
    {
        Disable();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0)) Throw?.Invoke();
    }

    private void OnEnable()
    {
        _endAnimationHandler.GrenadeDropped += DropGrenade;
    }

    public Grenade SpawnGrenade(Grenade grenade)
    {
        _grenadePrefabByDefault = grenade;
        _spawnedGrenade = SpawnGrenade();
        return _spawnedGrenade;
    }

    public void Initialization(RayInput rayInput)
    {
        _rayInput = rayInput;
        _targetingRay.Initialization(_rayInput);
    }

    public event Action Throw;

    public void Enable()
    {
        enabled = true;
        _rayInput.Enable();
        _targetingRay.Enable();
    }

    public void Disable()
    {
        _targetingRay.Disable();
        if (_rayInput != null)
            _rayInput.Disable();
        enabled = false;
    }

    private Grenade SpawnGrenade()
    {
        var grenade = Instantiate(_grenadePrefabByDefault, _targetingRay.transform.position, Quaternion.identity);
        grenade.gameObject.SetActive(true);
        grenade.Initialization(_targetingRay.transform);
        grenade.Scaler.Scale(false);
        return grenade;
    }

    public void DisarmSpawnGrenade()
    {
        _spawnedGrenade.Destroy();
    }

    public void DropGrenadeTo(Vector3 target, Action bossHitted)
    {
        _spawnedGrenade.DropTo(target, bossHitted);
    }

    private void DropGrenade()
    {
        _spawnedGrenade.DropTo(_rayInput.TargetPoint, null);
        _endAnimationHandler.GrenadeDropped -= DropGrenade;
    }
}