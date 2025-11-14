using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameObject winPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            winPanel.SetActive(true);
        }
    }
}
