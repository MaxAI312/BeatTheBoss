using UnityEngine;
using DG.Tweening;

public class ItemPhysics : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _allRigidbodies;

    private float delayBeforeCallback = 0.3f;
    
    public void MakePhysics()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(delayBeforeCallback);
        sequence.AppendCallback(() =>
        {
            foreach (var rigidbody in _allRigidbodies) rigidbody.isKinematic = false;
        });
    }
}