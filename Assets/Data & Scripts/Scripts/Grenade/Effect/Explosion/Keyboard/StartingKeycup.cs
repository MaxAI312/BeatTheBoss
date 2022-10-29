using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class StartingKeycup : MonoBehaviour, IPhysics
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void MakePhysics()
    {
        _rigidbody.isKinematic = false;
    }

    public void PushByLocalY()
    {
        transform.DOLocalMoveY(transform.localPosition.y + 2f, 0.75f);//MAGIC INT
    }
}
