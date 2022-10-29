using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Transformable : MonoBehaviour
{
    [Header("Push Settings")]
    [SerializeField] private float _offsetPushX;
    [SerializeField] private float _offsetPushY;
    [SerializeField] private float _offsetPushZ;

    [Header("Toss Settings")]
    [SerializeField] private float _offsetTossX;
    [SerializeField] private float _offsetTossY;
    [SerializeField] private float _offsetTossZ;

    [Header("Press  Settings")]
    [SerializeField] private float _offsetPressX;
    [SerializeField] private float _offsetPressY;
    [SerializeField] private float _offsetPressZ;

    [Header("Other Settings")]
    [SerializeField] private float _durationOffset = 0.4f;
    [SerializeField] private bool _isLeft;
    [SerializeField] private bool _isRight;

    public void Push()
    {
        if (_isLeft)
        {
            transform.DOMoveZ(transform.position.z + _offsetPushZ, _durationOffset);
            transform.DOMoveX(transform.position.x - _offsetPushX, _durationOffset);
        }

        if (_isRight)
        {
            transform.DOMoveZ(transform.position.z + _offsetPushZ, _durationOffset);
            transform.DOMoveX(transform.position.x + _offsetPushX, _durationOffset);
        }
    }

    public void Toss()
    {
        if (_isLeft)
        {
            Vector3 target = new Vector3(transform.position.x - _offsetTossX,
                                        transform.position.y + _offsetTossY,
                                        transform.position.z + _offsetTossZ);

            transform.DOMove(target, _durationOffset);
        }

        if (_isRight)
        {

            Vector3 target = new Vector3(transform.position.x + _offsetTossX,
                                        transform.position.y + _offsetTossY,
                                        transform.position.z + _offsetTossZ);
            transform.DOMove(target, _durationOffset);
        }
    }

    public void Press()
    {
        if (_isLeft)
        {
            Vector3 target = new Vector3(transform.position.x - _offsetPressX,
                                        transform.position.y - _offsetPressY,
                                        transform.position.z + _offsetPressZ);

            transform.DOMove(target, _durationOffset);
        }

        if (_isRight)
        {
            Vector3 target = new Vector3(transform.position.x + _offsetPressX,
                                        transform.position.y - _offsetPressY,
                                        transform.position.z + _offsetPressZ);

            transform.DOMove(target, _durationOffset);
        }
    }
}
