using UnityEngine;

public class ZeroRoadSector : MonoBehaviour
{
    [SerializeField] private Material _materialForColor;

    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var boss = other.GetComponent<Boss>();
        if (boss)
            _meshRenderer.material = _materialForColor;
    }
}