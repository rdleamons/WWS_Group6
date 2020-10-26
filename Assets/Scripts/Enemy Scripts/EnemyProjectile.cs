using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    Enemy enemy;
    Player player;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerBody"))
        {
            player.takeDamage();
            Destroy(gameObject);
        }
        
        if (col.CompareTag("Killzone"))
        {
            Destroy(gameObject);
        }
    }
}
