using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireballPrefab;
    public Enemy enemy;
    public Transform target;

    private float activateTime = 1.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            InvokeRepeating("Shoot", activateTime, activateTime);  
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            CancelInvoke("Shoot");
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
        firePoint.transform.LookAt(target); 
        
    }
}