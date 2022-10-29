public class PlayState : IState
{
    private readonly Boss _boss;
    private readonly Player _player;
    private readonly UI _uI;
    private readonly MainCameraContainer _mainCameraContainer;

    public PlayState(UI uI, Player player, Boss boss, MainCameraContainer mainCameraContainer)
    {
        _uI = uI;
        _player = player;
        _boss = boss;
        _mainCameraContainer = mainCameraContainer;
    }

    public void Enter()
    {
        _mainCameraContainer.CameraFollowing.enabled = true;
        _uI.PlayMenu.Show();
        _player.UIWidgetRageCounter.Show();
        _player.StartMove();
        _player.PlayerAnimator.ResetTurn();
        _player.PlayerAnimator.ShowRun();
        _boss.Arrow.Show();
        _boss.StartMove();
        _boss.BossAnimator.ShowRun();
    }

    public void Exit()
    {
        _uI.PlayMenu.Hide();
        _player.UIWidgetRageCounter.Hide();
    }
}