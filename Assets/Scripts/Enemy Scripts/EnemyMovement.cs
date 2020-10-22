using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool inCombat;
    public float wanderTime;
    public float moveSpeed = 0.5f;
    private float speed = 0;

    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer enemyRenderer;

    public Player player;
    public EnemyWeapon weapon;
    GameObject whichEnemy;
    
    Vector2 movement;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        enemyRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moveSpeed = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moveSpeed = 0.5f;
        }
    }

    private void Update()
    {
        whichEnemy = player.thisOne;

        if (player.enemyDead == false)
        {
            if(wanderTime > 0)
            {
                wanderTime -= Time.deltaTime;
            }
            else
            {
                wanderTime = Random.Range(1f, 3f);
                wander();
            }
        }

        if (movement.x > 0)
        {
            anim.SetBool("xInc", true);
            anim.SetBool("xDec", false);

            enemyRenderer.flipX = false;
            weapon.transform.Rotate(0f, 0f, 0f);
        }
        else if (movement.x < 0)
        {
            anim.SetBool("xDec", true);
            anim.SetBool("xInc", false);

            enemyRenderer.flipX = true;
            weapon.transform.Rotate(0f, 180f, 0f);
        }
        else if (movement.x == 0)
        {
            anim.SetBool("xDec", false);
            anim.SetBool("xInc", false);
        }

        if (speed == 0)
        {
            anim.SetBool("xDec", false);
            anim.SetBool("xInc", false);
            anim.SetBool("yDec", false);
            anim.SetBool("yInc", false);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        speed = movement.magnitude / Time.deltaTime;

        anim.SetFloat("Speed", speed);
       
    }

    void wander()
    {
        movement.x = Random.Range(-5f, 5f);
    }
}
