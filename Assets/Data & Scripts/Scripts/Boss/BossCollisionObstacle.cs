using UnityEngine;

public class BossCollisionObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var boss = other.GetComponent<Boss>();

        if (boss) boss.BossAnimator.ShowJump();
    }
}