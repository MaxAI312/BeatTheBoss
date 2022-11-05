using UnityEngine;

public class UIWidgetForceView : MonoBehaviour
{
    [SerializeField] private UIText _uIText;

    public void SetText(string text)
    {
        _uIText.SetText(text);
    }
    
    public void SetTextColor(Color color)
    {
        _uIText.SetTextColor(color);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}