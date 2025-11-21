using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int coins = 0;

    public static event Action OnPlayerDie;
    public static event Action OnGameWin;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetCoins()
    {
        coins = 0;
        Debug.Log("Coins reset to zero.");
    }

    public void AddCoin(int amount)
    {
        coins += amount;
        Debug.Log("Coins: " + coins);
    }

    public void PlayerDied()
    {
        OnPlayerDie?.Invoke();
        Debug.Log("Game Over");
    }

    public void GameWon()
    {
        OnGameWin?.Invoke();
        Debug.Log("Game Win!");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}