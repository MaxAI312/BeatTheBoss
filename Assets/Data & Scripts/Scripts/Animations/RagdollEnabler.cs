using RootMotion.Dynamics;
using UnityEngine;

public class RagdollEnabler : MonoBehaviour
{
    [SerializeField] private PuppetMaster _puppetMaster;
    [SerializeField] private Animator _animator;

    //Used in animator office workers
    public void Handler_EnableRagdoll()
    {
        _puppetMaster.pinWeight = 0f;

        _animator.enabled = false;
    }
}
