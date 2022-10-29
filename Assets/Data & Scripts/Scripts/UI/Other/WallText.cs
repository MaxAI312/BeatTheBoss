using TMPro;
using UnityEngine;

public class WallText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public string Text => _text.text;

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}