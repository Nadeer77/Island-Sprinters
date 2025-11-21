using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string nextLevelName;
    public GameObject winPanel;
    public GameObject gameOverPanel;

    void Start()
    {
        GameManager.instance.ResetCoins();
    }

    public void WinLevel()
    {
        GameManager.instance.GameWon();
        Time.timeScale = 0;
        if (winPanel != null)
            winPanel.SetActive(true);
    }

    public void LoseLevel()
    {
        GameManager.instance.PlayerDied();
        Time.timeScale = 0;
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1;
        if (!string.IsNullOrEmpty(nextLevelName))
            SceneManager.LoadScene(nextLevelName);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        GameManager.instance.RestartLevel();
    }
}
