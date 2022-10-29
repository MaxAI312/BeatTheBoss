using UnityEngine;

public class BotsHandler : MonoBehaviour
{
    [SerializeField] private BotTrigger[] _triggers;
    [SerializeField] private Bot[] _workers;

    private void OnEnable()
    {
        foreach (var trigger in _triggers) trigger.TriggerTaken += OnTriggerTaken;
    }

    private void OnDisable()
    {
        foreach (var trigger in _triggers) trigger.TriggerTaken -= OnTriggerTaken;
    }

    private void OnTriggerTaken(int indexTrigger)
    {
        if (_workers.Length != _triggers.Length)
            Debug.Log("_workers.Length != _triggers.Length");

        _workers[indexTrigger].PlayAnimation();
    }
}