using System;
using UnityEngine;

public class SlapHandler : MonoBehaviour
{
    private int _highSlapIndex = 2;
    private int _middleSlapIndex = 1;
    private int _lowSlapIndex = 0;

    public event Action<int> IndexSlapChanged;

    //Used in Slap Animations
    public void Handler_SetHighSlapIndex()
    {
        IndexSlapChanged?.Invoke(_highSlapIndex);
    }

    //Used in Slap Animations
    public void Handler_SetMiddleSlapIndex()
    {
        IndexSlapChanged?.Invoke(_middleSlapIndex);
    }

    //Used in Slap Animations
    public void Handler_SetLowSlapIndex()
    {
        IndexSlapChanged?.Invoke(_lowSlapIndex);
    }
}
