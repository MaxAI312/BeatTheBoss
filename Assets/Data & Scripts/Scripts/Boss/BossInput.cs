using RunnerMovementSystem;
using UnityEngine;

public class BossInput : MonoBehaviour
{
    [SerializeField] private MovementSystem _movementSystem;

    private void Update()
    {
        _movementSystem.MoveForward();
    }

    public void Enable()
    {
        enabled = true;
    }

    public void Disable()
    {
        enabled = false;
    }
}