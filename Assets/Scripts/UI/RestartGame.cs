using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public static RestartGame instance;
    public GameObject GameOverPanel;
    void Awake()
    {
        instance = this;
    }
    public void Restart()
    {
        // Reset time in case game was paused
        Time.timeScale = 1;

        // Reload the current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
