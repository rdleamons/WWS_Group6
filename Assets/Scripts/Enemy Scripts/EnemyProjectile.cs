using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    Enemy enemy;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Player player = col.GetComponent<Player>();
        if (col.CompareTag("PlayerBody"))
        {
            player.takeDamage();
        }
        
        if (col.CompareTag("Killzone"))
        {
            Destroy(gameObject);
        }
    }
}
