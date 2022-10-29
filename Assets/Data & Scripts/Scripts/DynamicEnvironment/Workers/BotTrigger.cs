using System;
using UnityEngine;

public class BotTrigger : MonoBehaviour
{
    [SerializeField] private int _numberOfTrigger;

    public int NumberOfTrigger => _numberOfTrigger;

    public event Action<int> TriggerTaken;

    public void SetTaken()
    {
        TriggerTaken?.Invoke(_numberOfTrigger);
    }
}