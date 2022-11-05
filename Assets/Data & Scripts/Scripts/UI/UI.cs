using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private PlayMenu _playMenu;
    [SerializeField] private SettingsMenu _settingsMenu;
    [SerializeField] private FinisherMenu _finisherMenu;
    [SerializeField] private EndLevelMenu _endLevelMenu;
    [SerializeField] private FailMenu _failMenu;
    [SerializeField] private GateMenu _gateMenu;

    public MainMenu MainMenu => _mainMenu;
    public PlayMenu PlayMenu => _playMenu;
    public SettingsMenu SettingsMenu => _settingsMenu;
    public FinisherMenu FinisherMenu => _finisherMenu;
    public EndLevelMenu EndLevelMenu => _endLevelMenu;
    public FailMenu FailMenu => _failMenu;
    public GateMenu GateMenu => _gateMenu;
}