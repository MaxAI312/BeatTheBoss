using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string Idle = nameof(Idle);
    private const string Run = nameof(Run);
    private const string Stumbling = nameof(Stumbling);
    private const string ThrowStart = nameof(ThrowStart);
    private const string ThrowEnd = nameof(ThrowEnd);
    private const string ThrowFinisher = nameof(ThrowFinisher);
    private const string Turn = nameof(Turn);
    private const string LeftSlap = nameof(LeftSlap);
    private const string RightSlap = nameof(RightSlap);
    private const string MiddleSlap = nameof(MiddleSlap);
    private const string SlapIndex = nameof(SlapIndex);
    private const string KnockedOut = nameof(KnockedOut);
    private const string Fail = nameof(Fail);
    private const string Typing = nameof(Typing);

    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private AvatarMask _throwAvatarMask;
    [SerializeField] private EndAnimationHandler _endAnimationHandler;
    [SerializeField] private float _turnSpeed = 30;
    [SerializeField] private float _sensitivity = 2;

    private float _currentTurnValue;

    public AvatarMask ThrowAvatarMask => _throwAvatarMask;

    public event Action ThrowEnded;

    public void SetTurn(float value)
    {
        value = Mathf.Clamp(value * _sensitivity, -1, 1);//MAGIC INT
        _currentTurnValue = Mathf.MoveTowards(_currentTurnValue, value, _turnSpeed * Time.deltaTime);
        _playerAnimator.SetFloat(Turn, _currentTurnValue);
    }

    public void ResetTurn()
    {
        _playerAnimator.SetFloat(Turn,0);//MAGIC INT
    }

    public void ShowIdle()
    {
        ResetTriggers();
        _playerAnimator.SetTrigger(Idle);
    }

    public void ShowTyping()
    {
        _playerAnimator.Play(Typing);
    }

    public void ShowKnockedOut()
    {
        ResetTriggers();
        _playerAnimator.SetTrigger(KnockedOut);
    }

    public void ShowRun()
    {
        ResetTriggers();
        _playerAnimator.SetTrigger(Run);
    }

    public void ShowStumbling()
    {
        ResetTriggers();
        _playerAnimator.SetTrigger(Stumbling);
    }

    public void ShowSlap()
    {
        ResetTriggers();
        _playerAnimator.SetTrigger(LeftSlap);
        
    }

    public void ShowRightHandSlapBy(int index)
    {
        _playerAnimator.ResetTrigger(RightSlap);
        _playerAnimator.SetLayerWeight(1,1);
        _playerAnimator.SetInteger(SlapIndex, index);
        _playerAnimator.SetTrigger(RightSlap);
    }

    public void ShowLeftHandSlapBy(int index)
    {
        _playerAnimator.ResetTrigger(LeftSlap);
        _playerAnimator.SetLayerWeight(2, 1);
        _playerAnimator.SetInteger(SlapIndex, index);
        _playerAnimator.SetTrigger(LeftSlap);
    }

    public void ShowMiddleSlapBy(int index)
    {
        _playerAnimator.ResetTrigger(RightSlap);
        _playerAnimator.ResetTrigger(LeftSlap);
        _playerAnimator.SetLayerWeight(3, 1);
        _playerAnimator.SetInteger(SlapIndex, index);
        _playerAnimator.SetTrigger(MiddleSlap);
    }

    public void ShowThrowPrepare(bool isFinisherThrow, Action ended)
    {
        _playerAnimator.SetFloat(Turn, 0);
        ResetTriggers();
        if (isFinisherThrow)
        {
            _playerAnimator.SetLayerWeight(4,0);//MAGIC INT
            _playerAnimator.SetLayerWeight(5,1);//MAGIC INT
        }
        else
        {
            _playerAnimator.SetLayerWeight(4,1);//MAGIC INT
        }
        _playerAnimator.SetTrigger(ThrowStart);
        _endAnimationHandler.WaitingForThrowPrepare(ended);
    }

    public void ShowThrowEnd()
    {
        ResetTriggers();
        _playerAnimator.SetTrigger(ThrowEnd);
        _endAnimationHandler.WaitingForThrowEnded(()=> ThrowEnded?.Invoke());
    }

    public void SetThrowGrenadeLayerWeightToZero()
    {
        _playerAnimator.SetLayerWeight(4,0);
    }

    public void ShowThrowFinisher(Action grenadeDropped)
    {
        ResetTriggers();
        _playerAnimator.SetLayerWeight(4,0);//MAGIC INT
        _playerAnimator.SetLayerWeight(5,1);//MAGIC INT
        _playerAnimator.SetTrigger(ThrowFinisher);
        _endAnimationHandler.WaitingForThrowPrepare(grenadeDropped);
    }

    public void ShowFail()
    {
        ResetTriggers();
        _playerAnimator.SetTrigger(Fail);
    }
    
    public void SetTimeScale(float value)
    {
        _playerAnimator.speed = value;
    }

    private void ResetTriggers()
    {
        _playerAnimator.ResetTrigger(Idle);
        _playerAnimator.ResetTrigger(Run);
        _playerAnimator.ResetTrigger(Stumbling);
        _playerAnimator.ResetTrigger(ThrowStart);
        _playerAnimator.ResetTrigger(ThrowEnd);
        _playerAnimator.ResetTrigger(ThrowFinisher);
        _playerAnimator.ResetTrigger(LeftSlap);
        _playerAnimator.ResetTrigger(RightSlap);
        _playerAnimator.ResetTrigger(KnockedOut);
        _playerAnimator.ResetTrigger(Fail);
    }
}