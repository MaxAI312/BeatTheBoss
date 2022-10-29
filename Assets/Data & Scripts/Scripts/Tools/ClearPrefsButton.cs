using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClearPrefsButton : MonoBehaviour
{
    private Button _clearPrefsButton;

    private void Awake()
    {
        _clearPrefsButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _clearPrefsButton.onClick.AddListener(ClearPrefs);
    }

    private void OnDisable()
    {
        _clearPrefsButton.onClick.RemoveListener(ClearPrefs);
    }

    private void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Prefs cleared");
    }
}