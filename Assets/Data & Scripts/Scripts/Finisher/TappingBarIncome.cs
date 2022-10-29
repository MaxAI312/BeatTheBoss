using System;
using UnityEngine;

public class TappingBarIncome : MonoBehaviour
{
    [SerializeField][Min(0)] private int _value;

    public event Action<int> Tapped;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Tapped?.Invoke(_value);
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
}
