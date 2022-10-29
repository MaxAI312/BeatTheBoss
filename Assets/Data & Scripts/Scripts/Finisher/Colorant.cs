using UnityEngine;

[ExecuteAlways]
public class Colorant : MonoBehaviour
{
    [SerializeField] private Material _evenSectorsMaterial;
    [SerializeField] private Material _oddSectorsMaterial;
    [SerializeField] private Gradient _gradient;

    private float _gradientStep;
    private int _oldCount;

    private void Start()
    {
        if (Application.IsPlaying(this))
        {
            CorrectColor();
            enabled = false;
        }

        _oldCount = transform.childCount;
    }

    private void Update()
    {
        if (_oldCount != transform.childCount)
        {
            _oldCount = transform.childCount;
            CorrectColor();
        }
    }

    private void OnValidate()
    {
        CorrectColor();
    }

    private void CorrectColor()
    {
        var roadSectors = GetComponentsInChildren<RoadSector>();

        if (roadSectors.Length <= 0)
            return;

        var gradientStep = 1.0f / roadSectors.Length;

        for (var i = 0; i < roadSectors.Length; i++)
        {
            var material = new Material(_evenSectorsMaterial);
            material.color = _gradient.Evaluate(gradientStep * i);

            if (i % 2 == 0)
                roadSectors[i].Initialization(_evenSectorsMaterial, material);
            else
                roadSectors[i].Initialization(_oddSectorsMaterial, material);
        }
    }
}