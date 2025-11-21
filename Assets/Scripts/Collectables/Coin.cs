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
            GameManager.instance.AddCoin(coinsToGive);
            Player player = collision.gameObject.GetComponent<Player>();
            player.PlaySFX(coinClip, 0.4f);
            coinText.text = GameManager.instance.coins.ToString();
            Destroy(gameObject);
            Debug.Log("Touched");
        }
    }
}
