using UnityEngine;
using DG.Tweening;

public class ItemRagdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _allRigidbodies;
    [SerializeField] private float _hitForce;
    
    public void MakePhysics()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(0.3f);//MAGIC INT
        sequence.AppendCallback(() =>
        {
            foreach (var rigidbody in _allRigidbodies) rigidbody.isKinematic = false;
        });
    }
}