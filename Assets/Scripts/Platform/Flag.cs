using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameObject winPanel;
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.GameWon();
            Time.timeScale = 0;
            winPanel.SetActive(true);
        }
    }
}
