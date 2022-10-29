using UnityEngine;

[RequireComponent(typeof(SwitchStateEmoji))]
public class ItemView : MonoBehaviour
{
    private SwitchStateEmoji _switchStateEmoji;

    private void Awake()
    {
        _switchStateEmoji = GetComponent<SwitchStateEmoji>();
    }

    public void EnableSwitchStateEmoji()
    {
        _switchStateEmoji.SwitchState();
    }
}
