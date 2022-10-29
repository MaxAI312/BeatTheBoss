using UnityEngine.Playables;

public class OpeningState : IState
{
    private readonly Boss _boss;
    private readonly PlayableDirector _director;
    private readonly MainCameraContainer _mainCameraContainer;
    private readonly Player _player;
    private readonly UI _ui;

    public OpeningState(UI ui, Player player, Boss boss, MainCameraContainer mainCameraContainer,
        PlayableDirector director)
    {
        _ui = ui;
        _player = player;
        _boss = boss;
        _mainCameraContainer = mainCameraContainer;
        _director = director;
    }

    public void Enter()
    {
        _director.enabled = true;
        _director.Play();
    }

    public void Exit()
    {
        _director.enabled = false;
    }
}