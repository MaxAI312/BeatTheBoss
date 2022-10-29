using UnityEngine;

public class MainCameraAnimator : MonoBehaviour
{
    private const string ThrowViewIn = nameof(ThrowViewIn);
    private const string ThrowViewOut = nameof(ThrowViewOut);
    private const string Ending = nameof(Ending);
    private const string FinisherAnimation = nameof(FinisherAnimation);
    private const string FinisherLastAnimation = nameof(FinisherLastAnimation);
    private const string PreFInisherCameraAnimation = nameof(PreFInisherCameraAnimation);

    [SerializeField] private Animator _animator;

    private void Awake()
    {
        Disable();
    }

    public void Enable()
    {
        _animator.enabled = true;
    }

    public void Disable()
    {
        _animator.enabled = false;
    }

    public void ShowThrowViewIn()
    {
        Enable();
        _animator.Play(ThrowViewIn);
    }

    public void ShowThrowViewOut()
    {
        Enable();
        _animator.Play(ThrowViewOut);
    }

    public void ShowPreFInisherCameraAnimation()
    {
        Enable();
        _animator.Play(PreFInisherCameraAnimation);
    }
    
    public void ShowFinisherAnimation()
    {
        Enable();
        _animator.Play(FinisherAnimation);
    }

    public void ShowFinisherLastAnimation()
    {
        Enable();
        _animator.Play(FinisherLastAnimation);
    }

    public void ShowEnding()
    {
        Enable();
        _animator.Play(Ending);
    }

    // Used in camera animation
    private void Handle_AnimatorDisable()
    {
        Disable();
    }
    
    // Used in camera animation
    private void Handle_TimeScaleReduce()
    {
        Time.timeScale = 0.3f;
    }
    
    // Used in camera animation
    private void Handle_TimeScaleReturnToNormal()
    {
        Time.timeScale = 1f;
    }
}