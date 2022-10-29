using UnityEngine;

[ExecuteAlways]
public class RoadSector : MonoBehaviour
{
    [SerializeField] private MeshRenderer _roadMeshRenderer;

    private Material _defaultMaterial;
    private Material _highlightMaterial;

    private void OnTriggerEnter(Collider other)
    {
        var boss = other.GetComponent<Boss>();
        if (boss)
            _roadMeshRenderer.material = _highlightMaterial;
    }

    public void Initialization(Material defaultMaterial, Material highlightMaterial)
    {
        _defaultMaterial = defaultMaterial;
        _highlightMaterial = highlightMaterial;
        
        _roadMeshRenderer.material = _defaultMaterial;
    }
}