using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 12f;
    public int damage = 50;
    public float lifetime = 2f;
    private float direction = 1f;

    void Start()
    {
        Destroy(gameObject, lifetime); 
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * direction * Time.deltaTime); 
    }

    public void SetDirection(float dir)
    {
        direction = dir;
        // Optional: Flip sprite if your bullet image requires it
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * Mathf.Sign(dir);
        transform.localScale = scale;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damage"))
        {
            Enemy enemy = collision.GetComponentInParent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if (!collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
