using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 12f;
    private SpriteRenderer spriteRenderer;

    public Transform gun; // Assign in Inspector - reference to the gun child GameObject
    public Vector3 gunPositionRight = new Vector3(5f, -0.2f, 0f); // Set for right hand
    public Vector3 gunPositionLeft  = new Vector3(-5f, -0.2f, 0f); // Set for left hand

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        bool facingRight = !spriteRenderer.flipX;

        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.F))
        {
            Shoot(facingRight);
        }

        FlipGunPosition(facingRight);
    }

    void Shoot(bool facingRight)
    {
        float direction = facingRight ? 1f : -1f;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetDirection(direction); // Pass direction to bullet
        }
    }

    void FlipGunPosition(bool facingRight)
    {
        gun.localPosition = facingRight ? gunPositionRight : gunPositionLeft;
        gun.localScale = new Vector3(facingRight ? 3f : -3f, 3f, 3f); // Only flip horizontally
    }
}