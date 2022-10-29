using UnityEngine;
using UnityEngine.Playables;

public class InitialState : IState
{
    private readonly Boss _boss;
    private readonly MainCameraContainer _mainCameraContainer;
    private readonly Player _player;
    private readonly UI _uI;
    private readonly PlayableDirector _director;
    private readonly Finisher _finisher;

    public InitialState(UI uI, Player player, Boss boss, MainCameraContainer mainCameraContainer, PlayableDirector director, Finisher finisher)
    {
        _uI = uI;
        _player = player;
        _boss = boss;
        _mainCameraContainer = mainCameraContainer;
        _director = director;
        _finisher = finisher;
    }

    public void Enter()
    {
        _mainCameraContainer.CameraFollowing.enabled = false;
        _boss.StopMove();
        _boss.Initialize(_finisher.Walls, _player.Rage);
        _boss.Arrow.Hide();
        _director.enabled = false;
        _uI.MainMenu.Show();
        _player.GrenadeThrower.Initialization(_mainCameraContainer.RayInput);
        _uI.FinisherMenu.MultiplierView.Initialize(_boss.CollisionHandler);
        _uI.GateMenu.UIWidgetTimerBar.Initialize(_player.GateTimer.Seconds, _player.GateTimer.Seconds.Value);
        _player.PlayerAnimator.ShowTyping();
        _player.StopMove();
        _player.UIWidgetRageBar.Hide();
        _player.UIWidgetRageCounter.Hide();

        for (int i = 0; i < _player.SlapParticles.Length; i++)
            _player.SlapParticles[i].DisableCollider();
    }

    public void Exit()
    {
        _uI.MainMenu.Hide();
    }
}