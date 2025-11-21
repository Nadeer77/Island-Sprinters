using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    private SpriteRenderer spriteRenderer;

    public Transform gun; // Reference to gun GameObject
    public Vector3 gunPositionRight = new Vector3(5f, -0.2f, 0f);
    public Vector3 gunPositionLeft  = new Vector3(-5f, -0.2f, 0f);

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
        GameObject bullet = BulletPool.instance.GetBullet(firePoint.position, direction);
        if (bullet == null)
        {
            Debug.LogWarning("No bullets available in pool");
        }
    }

    void FlipGunPosition(bool facingRight)
    {
        gun.localPosition = facingRight ? gunPositionRight : gunPositionLeft;
        gun.localScale = new Vector3(facingRight ? 3f : -3f, 3f, 3f);
    }
}