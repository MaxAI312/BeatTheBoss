using System;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        var itemView = other.GetComponentInParent<ItemView>();
        var trap = other.GetComponentInParent<Trap>();
        var trapView = other.GetComponentInParent<TrapView>();
        var gate = other.GetComponent<Gate>();
        var gateView = other.GetComponent<GateView>();
        var finisher = other.GetComponentInParent<Finisher>();
        var workerTrigger = other.GetComponentInParent<BotTrigger>();
        var guard = other.GetComponent<ItemGuard>();

        if (item)
        {
            ItemTaken?.Invoke(item);
            item.Disable();
        }

        if (trap)
        {
            trap.Disable();
            TrapTaken?.Invoke(trap);
        }

        if (trapView) trapView.DestroyTrap();

        if (gate)
        {
            gate.Disable();
            GateTaken?.Invoke(gate.GrenadePrefab);
        }

        if (gateView)
        {
            gateView.ShowDisappear();
        }

        if (finisher)
        {
            finisher.DisableTrigger();
            FinisherTaken?.Invoke();
        }

        if (workerTrigger) workerTrigger.SetTaken();

        if (guard)
        {
            ItemGuardTaken?.Invoke(guard);
        }
    }
    
    public void Enable()
    {
        enabled = true;
    }

    public void Disable()
    {
        enabled = false;
    }

    public event Action<Item> ItemTaken;
    public event Action<Trap> TrapTaken;
    public event Action<Grenade> GateTaken;
    public event Action<ItemGuard> ItemGuardTaken;
    public event Action FinisherTaken;
    public event Action BossSlapped;
}