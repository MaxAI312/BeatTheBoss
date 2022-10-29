using System.Collections.Generic;
using UnityEngine;

public class Finisher : MonoBehaviour
{
    [SerializeField] private FinisherTrigger _finisherTrigger;
    [SerializeField] [Min(1)] private int _wallCost;
    [SerializeField] private FinisherRoadModel _finisherRoadModel;

    public int WallCost => _wallCost;
    public IReadOnlyList<Wall> Walls => _finisherRoadModel.Walls;

    private void Awake()
    {
        Hide();
    }

    public void DisableTrigger()
    {
        _finisherTrigger.Disable();
    }

    public void Show()
    {
        _finisherRoadModel.Show();
    }

    public void Hide()
    {
        _finisherRoadModel.Hide();
    }
}