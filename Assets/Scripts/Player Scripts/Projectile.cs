using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 10;
    public Player player;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Enemy enemy = col.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
