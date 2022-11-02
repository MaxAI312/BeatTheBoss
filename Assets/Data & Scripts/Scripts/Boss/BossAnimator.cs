using System.Collections;
using UnityEngine;

public class BossAnimator : MonoBehaviour
{
    private const string Idle = nameof(Idle);
    private const string Run = nameof(Run);
    private const string Jump = nameof(Jump);
    private const string Terrified = nameof(Terrified);
    private const string Finisher = nameof(Finisher);
    private const string FallingBack = nameof(FallingBack);
    private const string WallHit = nameof(WallHit);
    private const string HitToBody = nameof(HitToBody);
    private const string Yelling = nameof(Yelling);
    private const string Fail = nameof(Fail);

    private int _targetLayerIndex = 1;
    private float _minWeightTargetLayer = 0;
    
    [SerializeField] private Animator _bossAnimator;
    [SerializeField] private AnimationCurve _hittedAnimationCurve;

    public void ShowIdle()
    {
        ResetTriggers();
        _bossAnimator.SetTrigger(Idle);
    }

    public void ShowJump()
    {
        ResetTriggers();
        _bossAnimator.SetTrigger(Jump);
    }

    public void ShowRun()
    {
        ResetTriggers();
        _bossAnimator.SetTrigger(Run);
    }

    public void ShowTerrified()
    {
        ResetTriggers();
        _bossAnimator.SetTrigger(Terrified);
    }

    public void ShowFinisher()
    {
        ResetTriggers();
        _bossAnimator.SetTrigger(Finisher);
    }

    public void ShowFallingBack()
    {
        ResetTriggers();
        _bossAnimator.SetTrigger(FallingBack);
    }

    public void ShowWallHit()
    {
        ResetTriggers();
        _bossAnimator.SetTrigger(WallHit);
    }

    public void ShowYelling()
    {
        ResetTriggers();
        _bossAnimator.SetTrigger(Yelling);
    }

    public void ShowHitToBody()
    {
        StartCoroutine(ShowingHitAnimation());
    }

    public void ShowFail()
    {
        ResetTriggers();
        _bossAnimator.SetTrigger(Fail);
    }

    public void SetTimeScale(float value)
    {
        _bossAnimator.speed = value;
    }

    public void Enable()
    {
        _bossAnimator.enabled = true;
    }

    public void Disable()
    {
        _bossAnimator.enabled = false;
    }

    private void ResetTriggers()
    {
        _bossAnimator.ResetTrigger(Idle);
        _bossAnimator.ResetTrigger(Run);
        _bossAnimator.ResetTrigger(Jump);
        _bossAnimator.ResetTrigger(Terrified);
        _bossAnimator.ResetTrigger(Finisher);
        _bossAnimator.ResetTrigger(FallingBack);
        _bossAnimator.ResetTrigger(WallHit);
        _bossAnimator.ResetTrigger(HitToBody);
        _bossAnimator.ResetTrigger(Yelling);
        _bossAnimator.ResetTrigger(Fail);
    }

    private IEnumerator ShowingHitAnimation()
    {
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            _bossAnimator.SetLayerWeight(_targetLayerIndex, _hittedAnimationCurve.Evaluate(i));

            yield return null;
        }
        _bossAnimator.SetLayerWeight(_targetLayerIndex, _minWeightTargetLayer);
    }
}