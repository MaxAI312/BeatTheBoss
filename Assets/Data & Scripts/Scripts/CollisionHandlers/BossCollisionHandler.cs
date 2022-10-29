using System;
using UnityEngine;

public class BossCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var grenade = other.GetComponent<Grenade>();
        var wall = other.GetComponent<Wall>();
        var brokenGlass = other.GetComponent<BrokenGlass>();
        var gateStopper = other.GetComponent<BossGateStopper>();

        if (grenade) GrenadeTaken?.Invoke(grenade);

        if (wall)
        {
            wall.WallPhysics.MakePhysics();
            wall.Text.Hide();
            WallTaken?.Invoke(wall);
        }

        if (gateStopper) StopperTaken?.Invoke();

        if (brokenGlass) brokenGlass.MakePhysics();
    }

    public event Action<Grenade> GrenadeTaken;
    public event Action<Wall> WallTaken;
    public event Action StopperTaken;
}