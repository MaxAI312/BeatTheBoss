using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Menu
{
    [SerializeField] private Button _startButton;

    public Button StartButton => _startButton;
}