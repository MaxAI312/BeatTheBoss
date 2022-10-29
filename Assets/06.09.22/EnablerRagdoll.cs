using RootMotion.Dynamics;
using UnityEngine;

public class EnablerRagdoll : MonoBehaviour//name
{
    [SerializeField] private PuppetMaster _puppetMaster;
    [SerializeField] private Animator _animator;


    public void EnableRagdoll()
    {
        _puppetMaster.pinWeight = 0f;

        _animator.enabled = false;
    }
}
