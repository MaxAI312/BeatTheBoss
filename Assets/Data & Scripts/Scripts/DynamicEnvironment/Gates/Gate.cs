using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private Grenade _grenadePrefab;
    [SerializeField] private Collider _gateTrigger;
    [SerializeField] private Collider[] _pairColliders;

    public Grenade GrenadePrefab => _grenadePrefab;

    public void Disable()
    {
        DisablePairColliders();
        _gateTrigger.enabled = false;
        _gateTrigger.gameObject.SetActive(false);
    }

    private void DisablePairColliders()
    {
        if(_pairColliders.Length == 0)
            return;

        foreach (var pairCollider in _pairColliders)
        {
            pairCollider.enabled = false;
        }
    }
}