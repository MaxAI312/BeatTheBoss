using System;
using UnityEngine;

public class EndAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;
    
    private int _layerIndexRightSlap = 1;
    private int _layerIndexLeftSlap = 2;
    private int _layerIndexMiddleSlap = 3;
    private float _targetWeight = 0f;

    private Action ThrowEnded;
    private Action ThrowPrepareEnded;

    public event Action GrenadeDropped;

    public void WaitingForThrowPrepare(Action callback)
    {
        ThrowPrepareEnded = callback;
    }

    public void WaitingForThrowEnded(Action callback)
    {
        ThrowEnded = callback;
    }

    // Used in throw end animation
    private void Handler_ThrowEnded()
    {
        ThrowEnded?.Invoke();
    }

    // Used in prepare throw animation
    private void Handler_ThrowPrepareEnded()
    {
        ThrowPrepareEnded?.Invoke();
    }

    private void Handler_DropGrenade()
    {
        GrenadeDropped?.Invoke();
    }
    
    // Used in Slap Animations
    private void Handler_EndRightSlap()
    {
        _playerAnimator.SetLayerWeight(_layerIndexRightSlap,_targetWeight);
    }
    
    // Used in Slap Animations
    private void Handler_EndLeftSlap()
    {
        _playerAnimator.SetLayerWeight(_layerIndexLeftSlap,_targetWeight);
    }
    
    // Used in Middle Slap Animations
    private void Handler_EndMiddleSlap()
    {

        _playerAnimator.SetLayerWeight(_layerIndexMiddleSlap,_targetWeight);
    }
}