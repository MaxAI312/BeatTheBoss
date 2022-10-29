using UnityEngine;
using DG.Tweening;

public class Follower : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    private void Update()
    {
        transform.DOMoveX(_target.transform.position.x, 0.1f);
        transform.DOMoveZ(_target.transform.position.z, 0.1f);
    }
}
