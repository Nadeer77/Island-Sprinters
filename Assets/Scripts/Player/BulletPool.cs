using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool instance;

    public GameObject bulletPrefab;
    public int poolSize = 6;

    private Queue<GameObject> bulletPool = new Queue<GameObject>();

    void Awake()
    {
        instance = this;

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet(Vector3 position, float direction)
    {
        // If no bullets available, return null
        if (bulletPool.Count == 0)
        {
            return null;
        }

        GameObject bullet = bulletPool.Dequeue();
        bullet.transform.position = position;
        bullet.SetActive(true);

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
            bulletScript.SetDirection(direction);

        return bullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}