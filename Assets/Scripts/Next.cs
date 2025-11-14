using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    public string nextLevelName;
    public int NextLevelValue;
    public void LoadNextLevel()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("LevelReached", NextLevelValue);
        SceneManager.LoadScene(nextLevelName);
    }
}
