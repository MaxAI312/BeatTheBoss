using UnityEngine;

public class BrokenGlass : MonoBehaviour
{
    [SerializeField] private GameObject _unbrokenGlassModel;
    [SerializeField] private GameObject[] _brokenGlassPices;

    public void MakePhysics()
    {
        _unbrokenGlassModel.SetActive(false);
        foreach (var glassPice in _brokenGlassPices) glassPice.SetActive(true);
    }
}