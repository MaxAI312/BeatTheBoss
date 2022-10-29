public class PauseState : IState
{
    private readonly Boss _boss;
    private readonly Player _player;
    private readonly UI _uI;

    public PauseState(UI uI, Player player, Boss boss)
    {
        _uI = uI;
        _player = player;
        _boss = boss;
    }

    public void Enter()
    {
        _uI.SettingsMenu.Show();
    }

    public void Exit()
    {
        _uI.SettingsMenu.Hide();
    }
}