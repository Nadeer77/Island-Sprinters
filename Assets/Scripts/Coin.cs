using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coinClip;
    public TextMeshProUGUI coinText;

    public int coinsToGive = 1;

    void Start()
    {
        coinText = GameObject.FindWithTag("CoinText").GetComponent<TextMeshProUGUI>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.coins += coinsToGive;
            player.PlaySFX(coinClip, 0.4f);
            coinText.text = player.coins.ToString();
            Destroy(gameObject); // destroy the coin
            Debug.Log("Touched");
        }
    }
}
