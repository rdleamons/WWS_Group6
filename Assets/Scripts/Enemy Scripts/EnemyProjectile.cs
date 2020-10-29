using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public Enemy enemy;
    public SpriteRenderer enemyRend;

    private int damage = 5;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        if(enemyRend.flipX == true)
            rb.velocity = transform.right * speed;
        else
            rb.velocity = -transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Player player = col.GetComponent<Player>();
        if (player != null & col.CompareTag("Player"))
        {
            player.takeDamage(damage);
            Destroy(gameObject);
        }
        /*
        if (col.CompareTag("Player"))
        {
            player.takeDamage(damage);
            
        }*/
        
        if (col.CompareTag("Killzone"))
        {
            Destroy(gameObject);
        }
    }
}
