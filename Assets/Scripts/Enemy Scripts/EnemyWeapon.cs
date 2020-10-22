using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireballPrefab;
    public Enemy enemy;
    public Player player;
    public HealthBar healthBar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Shoot();
        }
    }

    IEnumerator ShootBullet()
    {
        Shoot();
        yield return new WaitForSeconds(1.0f);
    }

    void Shoot()
    {
        Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
    }
}