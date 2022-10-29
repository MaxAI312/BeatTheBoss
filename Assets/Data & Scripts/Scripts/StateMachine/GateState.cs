public class GateState : IState
{
    private readonly Boss _boss;
    private readonly MainCameraContainer _mainCameraContainer;
    private readonly Player _player;
    private readonly ParameterAnimator _timeScaleAnimator;
    private readonly UI _ui;

    public GateState(UI ui, Player player, Boss boss, MainCameraContainer mainCameraContainer,
        ParameterAnimator timeScaleAnimator)
    {
        _ui = ui;
        _player = player;
        _boss = boss;
        _mainCameraContainer = mainCameraContainer;
        _timeScaleAnimator = timeScaleAnimator;
    }

    public void Enter()
    {
        _ui.GateMenu.Show();
        _ui.GateMenu.UIWidgetTimerBar.Show();
        _mainCameraContainer.CameraDirector.Enable();
        _mainCameraContainer.MainCameraAnimator.ShowThrowViewIn();
        _player.CollisionHandler.Disable();
        _player.PlayerAnimator.ResetTurn();
        _player.PlayerAnimator.ShowThrowPrepare(false, _player.GrenadeThrower.Enable);
        _player.GateTimer.Enable();
        _player.GrenadeThrower.Throw += OnThrowStarted;
        _player.GateTimer.TimeIsOver += OnTimeIsOver;

        _player.MouseInput.StopControl();
        
        _boss.StartMove();
        _boss.BossAnimator.ShowRun();
    }

    public void Exit()
    {
        _ui.GateMenu.Hide();
        _player.CollisionHandler.Enable();
        _player.PlayerAnimator.ResetTurn();
        _player.GateTimer.TimeIsOver -= OnTimeIsOver;
        _player.GrenadeThrower.Throw -= OnThrowStarted;
        _player.GrenadeThrower.Disable();
        _player.PlayerAnimator.SetThrowGrenadeLayerWeightToZero();
        _mainCameraContainer.MainCameraAnimator.ShowThrowViewOut();

        _player.MouseInput.StartControl();
    }

    private void OnThrowStarted()
    {
        _player.GateTimer.Disable();
        _ui.GateMenu.UIWidgetTimerBar.Hide();
        _mainCameraContainer.CameraDirector.Disable();
        _player.GrenadeThrower.Disable();
        _player.PlayerAnimator.ShowThrowEnd();
    }

    private void OnTimeIsOver()
    {
        _player.GrenadeThrower.DisarmSpawnGrenade();
        _mainCameraContainer.CameraDirector.Disable();
    }
}