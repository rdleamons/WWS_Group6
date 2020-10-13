using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool inCombat;
    public float wanderTime;
    public float moveSpeed = 0.25f;
    private float speed = 0;

    public Rigidbody2D rb;

    GameObject thePlayer;
    public Player player;

    GameObject whichEnemy;
    public Animator anim;

    public SpriteRenderer enemyRenderer;

    Vector2 movement;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        enemyRenderer = gameObject.GetComponent<SpriteRenderer>();

        thePlayer = GameObject.Find("Player");
        player = thePlayer.GetComponent<Player>();
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

        if (player.enemyNear == true)
        {
            moveSpeed = 0;
            anim.SetFloat("Speed", moveSpeed);
        }
        else
        {
            moveSpeed = 0.25f;
        }

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

        if (movement.y > 0)
        {
            anim.SetBool("yInc", true);
            anim.SetBool("yDec", false);

        }
        else if (movement.y < 0)
        {
            anim.SetBool("yDec", true);
            anim.SetBool("yInc", false);
        }
        else if (movement.y == 0)
        {
            anim.SetBool("yDec", false);
            anim.SetBool("yInc", false);
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
        movement.x = Random.Range(-10f, 10f);
        movement.y = Random.Range(-10f, 10f);
    }
}
