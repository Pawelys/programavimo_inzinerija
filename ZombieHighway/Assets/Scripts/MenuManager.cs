using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Scene"); // or use index: LoadScene(1)
    }

    public void OpenSettings()
    {
        // Load settings panel or scene
        SceneManager.LoadScene("Settings_Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit"); // visible in editor
    }
}