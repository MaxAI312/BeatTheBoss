using TMPro;
using UnityEngine;

public class FinalDamageText : MonoBehaviour
{
    [SerializeField] private TMP_Text _damageText;

    public void SetTextValue(int value)
    {
        _damageText.text = value.ToString();
    }
}