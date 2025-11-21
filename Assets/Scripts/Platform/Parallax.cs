using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed = 0.05f;

    private Transform cam;
    private float startY;   // background's starting Y position

    void Start()
    {
        cam = Camera.main.transform;
        startY = transform.position.y;    // keep Y fixed
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = cam.position.x * speed;   // only moves in X
        pos.y = startY;                   // never move in Y
        transform.position = pos;
    }
}
