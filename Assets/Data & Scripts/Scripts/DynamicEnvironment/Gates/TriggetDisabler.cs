using UnityEngine;

public class TriggetDisabler : MonoBehaviour
{
    [SerializeField] private Collider[] _triggerColliders;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponentInParent<Player>();

        if (player)
            foreach (var collider in _triggerColliders)
                collider.gameObject.SetActive(false);
    }
}