using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : Menu
{
    [SerializeField] private Button _resumeButton;

    public Button ResumeButton => _resumeButton;
}