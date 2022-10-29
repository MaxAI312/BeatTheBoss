using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] protected Image ImgFiller;

    public void SetValue(float valueNormalized)
    {
        ImgFiller.fillAmount = valueNormalized;
    }
}
