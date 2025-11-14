using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject startMainmenu;
    public GameObject levelSelect;
    public void StartGame(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void LevelSelect()
    {
        startMainmenu.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void QuitGaame()
    {
        Application.Quit();
    }
}
