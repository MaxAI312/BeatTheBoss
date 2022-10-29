using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class NextLevelButton : MonoBehaviour
{
    private Button _selfButton;

    private void Awake()
    {
        _selfButton = GetComponent<Button>();
        Debug.Log("Удалить после добавления аналитики.");
    }

    private void OnEnable()
    {
        _selfButton.onClick.AddListener(LoadNextLevel);
    }

    private void OnDisable()
    {
        _selfButton.onClick.RemoveListener(LoadNextLevel);
    }

    private void LoadNextLevel()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        var nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
            nextSceneIndex = 0;
        

        SceneManager.LoadScene(nextSceneIndex);
    }
}