using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    public void Rotate()
    {
        transform.Rotate(new Vector3(Vector3.zero.x, _rotationSpeed, Vector3.zero.z) * Time.deltaTime);
    }
}
