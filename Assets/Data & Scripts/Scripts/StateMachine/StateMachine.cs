using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private UI _uI;
    [SerializeField] private Player _player;
    [SerializeField] private Boss _boss;
    [SerializeField] private MainCameraContainer _mainCameraContainer;
    [SerializeField] private PlayableDirector _playableDirector;
    [SerializeField] private Finisher _finisher;
    [SerializeField] private ParameterAnimator _timeScaleAnimator;
    
    private Dictionary<Type, IState> _statesMap;
    private IState _currentState;

    private void Awake()
    {
        InitStates();
    }

    private void OnEnable()
    {
        _uI.MainMenu.StartButton.onClick.AddListener(SetOpeningState);
        _uI.SettingsMenu.ResumeButton.onClick.AddListener(SetPlayState);

        _player.CollisionHandler.GateTaken += SetGateState;
        _player.GateTimer.TimeIsOver += SetPlayState;
        _player.CollisionHandler.FinisherTaken += SetFinisherState;
        _player.PlayerAnimator.ThrowEnded += SetPlayState;
    }

    private void OnDisable()
    {
        _uI.MainMenu.StartButton.onClick.RemoveListener(SetOpeningState);
        _uI.SettingsMenu.ResumeButton.onClick.RemoveListener(SetPlayState);

        _player.CollisionHandler.GateTaken -= SetGateState;
        _player.GateTimer.TimeIsOver -= SetPlayState;
        _player.CollisionHandler.FinisherTaken -= SetFinisherState;
        _player.PlayerAnimator.ThrowEnded -= SetPlayState;
    }

    private void Start()
    {
        SetStateByDefault();
    }

    private void InitStates()
    {
        _statesMap = new Dictionary<Type, IState>
        {
            [typeof(InitialState)] = new InitialState(_uI, _player, _boss,_mainCameraContainer, _playableDirector, _finisher),
            [typeof(OpeningState)] = new OpeningState(_uI, _player, _boss, _mainCameraContainer, _playableDirector),
            [typeof(PlayState)] = new PlayState(_uI, _player, _boss, _mainCameraContainer),
            [typeof(PauseState)] = new PauseState(_uI, _player, _boss),
            [typeof(FinisherState)] = new FinisherState(_uI, _player, _boss,_mainCameraContainer, _finisher, this),
            [typeof(EndLevelState)] = new EndLevelState(_uI, _player, _boss),
            [typeof(FailState)] = new FailState(_uI, _player, _boss),
            [typeof(GateState)] = new GateState(_uI, _player, _boss, _mainCameraContainer, _timeScaleAnimator)
        };
    }

    private void SetInitialState()
    {
        var state = GetState<InitialState>();
        SetState(state);
    }

    private void SetOpeningState()
    {
        var state = GetState<OpeningState>();
        SetState(state);
    }

    public void SetPlayState()
    {
        var state = GetState<PlayState>();
        SetState(state);
    }

    private void SetPauseState()
    {
        var state = GetState<PauseState>();
        SetState(state);
    }

    private void SetFinisherState()
    {
        var state = GetState<FinisherState>();
        SetState(state);
    }

    public void SetEndlevelState()
    {
        var state = GetState<EndLevelState>();
        SetState(state);
    }

    public void SetFailState()
    {
        var state = GetState<FailState>();
        SetState(state);
    }

    private void SetGateState(Grenade grenade)
    {
        var state = GetState<GateState>();
        SetState(state);
    }

    private void SetStateByDefault()
    {
        SetInitialState();
    }
    
    private void SetState(IState newState)
    {
        if(_currentState != null)
            _currentState.Exit();

        _currentState = newState;
        _currentState.Enter();
    }

    private IState GetState<T>() where T : IState
    {
        var type = typeof(T);
        return _statesMap[type];
    }
}