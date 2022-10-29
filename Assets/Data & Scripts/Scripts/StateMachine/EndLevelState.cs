public class EndLevelState : IState
{
    private readonly Boss _boss;
    private readonly Player _player;
    private readonly UI _uI;

    public EndLevelState(UI uI, Player player, Boss boss)
    {
        _uI = uI;
        _player = player;
        _boss = boss;
    }

    public void Enter()
    {
        _uI.EndLevelMenu.FinalDamageText.SetTextValue(GetFinalDamageValue());
        _uI.EndLevelMenu.Show();
        _boss.PlayFinisherParticles();
    }

    public void Exit()
    {
        _uI.EndLevelMenu.Hide();
    }

    private int GetFinalDamageValue()
    {
        var finalDamage = _boss.TakenDamage * _boss.MultiplierValue;

        return (int)finalDamage;
    }
}