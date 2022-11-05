using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class StartingKeycup : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float targetPositionX = 2f;
    private float durationPushing = 0.75f;

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
        transform.DOLocalMoveY(transform.localPosition.y + targetPositionX, durationPushing);
    }
}
