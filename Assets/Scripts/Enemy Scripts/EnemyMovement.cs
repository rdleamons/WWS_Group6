using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool inCombat;
    public float wanderTime;
    public float moveSpeed = 0.5f;

    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer enemyRenderer;

    public Player player;
    public EnemyProjectile weapon;
    GameObject whichEnemy;
    
    Vector2 movement;
    public Vector2 target;

    private void Start()
    {
        //target = GameObject.FindWithTag("Player").transform;
        anim = gameObject.GetComponent<Animator>();
        enemyRenderer = gameObject.GetComponent<SpriteRenderer>();

        wanderTime = Random.Range(1f, 3f);
        StartCoroutine("wander");
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moveSpeed = 0.0f;
            StopCoroutine("wander");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moveSpeed = 0.5f;
            StartCoroutine("wander");
        }
    }

    private void Update()
    {
        whichEnemy = player.thisOne;

        if (movement.x > 0)
        {
            anim.SetBool("xInc", true);
            anim.SetBool("xDec", false);

            enemyRenderer.flipX = false;
        }
        else if (movement.x < 0)
        {
            anim.SetBool("xDec", true);
            anim.SetBool("xInc", false);

            enemyRenderer.flipX = true;
        }
        else if (movement.x == 0)
        {
            anim.SetBool("xDec", false);
            anim.SetBool("xInc", false);
        }

        if (moveSpeed == 0)
        {
            anim.SetBool("xDec", false);
            anim.SetBool("xInc", false);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        anim.SetFloat("Speed", moveSpeed);
       
    }

    void wander()
    {
        movement.x = Random.Range(-5f, 5f);
    }
}
