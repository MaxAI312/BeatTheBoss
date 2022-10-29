using UnityEngine;

public class ChairExplosion : Explosion
{
    private MeshRenderer[] _meshRenderers;
    
    public override void Explode()
    {
        base.Explode();

        _meshRenderers = GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < _meshRenderers.Length; i++)
        {
            _meshRenderers[i].enabled = false;
        }
    }
}
