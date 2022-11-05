using UnityEngine;
using DG.Tweening;

public class Follower : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    private float _durationMoveX = 0.1f;
    private float _durationMoveZ = 0.1f;
    
    private void Update()
    {
        transform.DOMoveX(_target.transform.position.x, _durationMoveX);
        transform.DOMoveZ(_target.transform.position.z, _durationMoveZ);
    }
}
