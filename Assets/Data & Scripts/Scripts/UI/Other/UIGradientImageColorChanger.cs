using UnityEngine;
using UnityEngine.UI;

public class UIGradientImageColorChanger : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Gradient _gradient;

    public void SetColorBy(float valueNormalized)
    {
        _image.color = _gradient.Evaluate(valueNormalized);
    }
}