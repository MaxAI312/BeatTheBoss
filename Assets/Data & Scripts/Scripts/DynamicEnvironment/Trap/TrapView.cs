using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObstacleDestroyer))]
public abstract class TrapView : MonoBehaviour
{
    private ObstacleDestroyer _obstacleDestroyer;

    private void Awake()
    {
        _obstacleDestroyer = GetComponent<ObstacleDestroyer>();
    }

    public virtual void DestroyTrap()
    {
        _obstacleDestroyer.MakePhysics();
    }
}
