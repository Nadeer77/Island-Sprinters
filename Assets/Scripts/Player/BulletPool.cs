using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool instance;

    public GameObject bulletPrefab;
    public int poolSize = 6;

    private List<GameObject> bulletPool = new List<GameObject>();

    void Awake()
    {
        instance = this;
        // Pre-instantiate bullets
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    public GameObject GetBullet(Vector3 position, float direction)
    {
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.transform.position = position;
                bullet.SetActive(true);
                Bullet bulletScript = bullet.GetComponent<Bullet>();
                if (bulletScript != null)
                    bulletScript.SetDirection(direction);
                return bullet;
            }
        }
        // Optionally create new bullet if pool exhausted
        return null;
    }
}
