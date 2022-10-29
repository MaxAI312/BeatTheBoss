using UnityEngine;
using UnityEngine.UI;

public class ShowFPS : MonoBehaviour
{
    public static float fps;
    [SerializeField] private Text _fpsText;

    private void OnGUI()
    {
        fps = 1.0f / Time.deltaTime;
        //GUILayout.Label("FPS: " + (int) fps);
        _fpsText.text = "FPS: " + (int) fps;
    }
}