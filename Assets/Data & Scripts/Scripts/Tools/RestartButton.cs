using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RestartButton : MonoBehaviour
{
    private Button _selfButton;

    private void Awake()
    {
        _selfButton = GetComponent<Button>();
        Debug.Log("Удалить после добавления аналитики.");
    }

    private void OnEnable()
    {
        _selfButton.onClick.AddListener(Restart);
    }

    private void OnDisable()
    {
        _selfButton.onClick.RemoveListener(Restart);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}