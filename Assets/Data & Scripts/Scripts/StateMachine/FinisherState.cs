using UnityEngine;

public class FinisherState : IState
{
    private readonly Boss _boss;
    private readonly Finisher _finisher;
    private readonly MainCameraContainer _mainCameraContainer;
    private readonly Player _player;
    private readonly StateMachine _stateMachine;
    private readonly UI _uI;

    public FinisherState(UI uI, Player player, Boss boss, MainCameraContainer mainCameraContainer, Finisher finisher,
        StateMachine stateMachine)
    {
        _uI = uI;
        _player = player;
        _boss = boss;
        _mainCameraContainer = mainCameraContainer;
        _finisher = finisher;
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        _player.TeapotController.PlaySecondParticle();
        _mainCameraContainer.MainCameraAnimator.ShowPreFInisherCameraAnimation();
        _boss.HeadCollider.Disable();
        
        _player.MouseInput.ReturnToDefaultPosition(() =>
        {
            if (_player.Rage.Value <= 0)
            {
                _stateMachine.SetFailState();
                return;
            }

            _uI.FinisherMenu.UIWidgetTapBar.Initialize(_player.Rage, _player.Rage.Value + (_player.Rage.Value / 2));
            _uI.FinisherMenu.UIWidgetTapBar.Hide();
            _uI.FinisherMenu.Show();
            _player.UIWidgetRageBar.Hide();
            _player.UIWidgetRageCounter.Hide();
            _player.StopMove();
            _player.PlayerAnimator.ShowIdle();
            _finisher.Show();
            _uI.FinisherMenu.EnableUICards();
            _uI.FinisherMenu.WeaponChooser.PickEnded += OnPickEnded;
        });
    }

    public void Exit()
    {
        _uI.FinisherMenu.Hide();
    }

    private void OnTicked(int value)
    {
        _player.AddRage(-value);
    }

    private void OnTapped(int value)
    {
        _player.AddRage(+value);
    }

    private void OnRageLimitIsOver()
    {
        _uI.FinisherMenu.TappingBarLoss.Ticked -= OnTicked;
        _uI.FinisherMenu.TappingBarIncome.Tapped -= OnTapped;

        _player.PlayerAnimator.ShowThrowFinisher(() =>
        {
            _player.GrenadeThrower.DropGrenadeTo(_boss.GrenadeTargetPoint.position, () =>
            {
                _mainCameraContainer.CameraFollowing.EnableBossCamera();
                _mainCameraContainer.MainCameraAnimator.ShowFinisherAnimation();
                _boss.BossAnimator.ShowFallingBack();
                var index = GetTargetWallIndexBy(_player.Rage.Value);
                _boss.Arrow.Hide();
                _boss.FinisherMover.PushToWallWith(index,
                    _mainCameraContainer.MainCameraAnimator.ShowFinisherLastAnimation, _stateMachine.SetEndlevelState);
            });
        });
        //Duplicate

        _uI.FinisherMenu.WeaponChooser.PickEnded -= OnPickEnded;
        _player.FinishTappigTimer.TimeIsOver -= OnTimeIsOver;
        _player.RageChecker.RageLimitIsOver -= OnRageLimitIsOver;
        _uI.FinisherMenu.UIWidgetTapBar.Hide();
        _uI.FinisherMenu.TappingHandPoint.Hide();
    }

    private void OnTimeIsOver()
    {
        _uI.FinisherMenu.TappingBarLoss.Ticked -= OnTicked;
        _uI.FinisherMenu.TappingBarIncome.Tapped -= OnTapped;

        _player.PlayerAnimator.ShowThrowFinisher(() =>
        {
            _player.GrenadeThrower.DropGrenadeTo(_boss.GrenadeTargetPoint.position, () =>
            {
                _mainCameraContainer.CameraFollowing.EnableBossCamera();
                _mainCameraContainer.MainCameraAnimator.ShowFinisherAnimation();
                _boss.Arrow.Hide();
                _boss.BossAnimator.ShowFallingBack();
                var index = GetTargetWallIndexBy(_player.Rage.Value);
                _boss.FinisherMover.PushToWallWith(index,
                    _mainCameraContainer.MainCameraAnimator.ShowFinisherLastAnimation, _stateMachine.SetEndlevelState);
            });
        });

        _uI.FinisherMenu.WeaponChooser.PickEnded -= OnPickEnded;
        _player.FinishTappigTimer.TimeIsOver -= OnTimeIsOver;
        _player.RageChecker.RageLimitIsOver -= OnRageLimitIsOver;
        _uI.FinisherMenu.UIWidgetTapBar.Hide();
        _uI.FinisherMenu.TappingHandPoint.Hide();
    }

    private void OnPickEnded(FinisherWeaponData weaponData)
    {
        _uI.FinisherMenu.TappingHandPoint.Show();
        var grenade = _player.GrenadeThrower.SpawnGrenade(weaponData.GrenadePrefab);
        grenade.FinisherScaler.Initilization(_player.Rage, _uI.FinisherMenu.TappingBarIncome, grenade.Scaler);
        grenade.FinisherScaler.Enable();

        _player.PlayerAnimator.ShowThrowPrepare(true, () =>
        {
            _uI.FinisherMenu.UIWidgetTapBar.Show();
            _uI.FinisherMenu.TappingBarLoss.Ticked += OnTicked;
            _uI.FinisherMenu.TappingBarIncome.Tapped += OnTapped;

            _player.FinishTappigTimer.Enable();
            _player.FinishTappigTimer.TimeIsOver += OnTimeIsOver;

            _player.RageChecker.Enable();
            _player.RageChecker.RageLimitIsOver += OnRageLimitIsOver;
        });
    }

    private int GetTargetWallIndexBy(int rageValue)
    {
        var index = 1 + rageValue / _finisher.WallCost;
        if (index >= _finisher.Walls.Count)
            index = _finisher.Walls.Count - 1;

        return index;
    }
}