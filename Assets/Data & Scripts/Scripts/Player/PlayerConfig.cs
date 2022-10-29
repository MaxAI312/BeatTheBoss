using System;
using UnityEngine;

[Serializable]
public class PlayerConfig
{
    [SerializeField] [Min(0)] private int _defaultRage;
    [SerializeField] [Min(0)] private int _maxRage = 100;
    [SerializeField] [Min(0)] private int _maxTapRage = 150;

    public int DefaultRage => _defaultRage;
    public int MaxRage => _maxRage;
    public int MaxTapRage => _maxTapRage;
}