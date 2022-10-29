using System;
using UnityEngine;

public class SlapHandler : MonoBehaviour
{
    private int _highSlapIndex = 2;
    private int _middleSlapIndex = 1;
    private int _lowSlapIndex = 0;

    public event Action<int> IndexSlapChanged;

    public void SetHighSlapIndex()
    {
        IndexSlapChanged?.Invoke(_highSlapIndex);
    }

    public void SetMiddleSlapIndex()
    {
        IndexSlapChanged?.Invoke(_middleSlapIndex);
    }

    public void SetLowSlapIndex()
    {
        IndexSlapChanged?.Invoke(_lowSlapIndex);
    }
}
