using System;
using UnityEngine;

public class EndAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;
    
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
    private void Handler_EndSlapRight()
    {
        _playerAnimator.SetLayerWeight(1,0);//MAGIC INT
    }
    
    // Used in Slap Animations
    private void Handler_EndSlapLeft()
    {
        _playerAnimator.SetLayerWeight(2,0);//MAGIC INT
    }
    
    // Used in Middle Slap Animations
    private void Handler_EndMiddleSlap()
    {

        _playerAnimator.SetLayerWeight(3,0);//MAGIC INT
    }
}