using UnityEngine;

[SelectionBase]
public class Item : MonoBehaviour
{
    [SerializeField] [Min(0)] private int _rageValue;
    [SerializeField] private Animator _animator;
    [SerializeField] private Collider _collider;

    private bool _isRageTaken;

    public int RageValue => _rageValue;

    public void Disable()
    {
        _animator.enabled = false;
        _collider.enabled = false;
    }
}