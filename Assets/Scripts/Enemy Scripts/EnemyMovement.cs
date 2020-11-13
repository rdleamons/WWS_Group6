using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 0.5f;

    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer enemyRenderer;

    public Player player;
    public EnemyProjectile weapon;
    private bool m_FacingRight = true;

    Vector2 movement;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        enemyRenderer = gameObject.GetComponent<SpriteRenderer>();

        StartCoroutine("wander");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moveSpeed = 0.0f;
            anim.SetBool("isAttacking", true);
            StopCoroutine("wander");
        }

        if(collision.CompareTag("TurnAround"))
        {
            movement.x = -movement.x;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moveSpeed = 0.5f;
            StartCoroutine("wander");
            anim.SetBool("isAttacking", true);
        }
    }

    private void Update()
    {
        if (movement.x > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (movement.x < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }

        /*
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
        */
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        anim.SetFloat("Speed", moveSpeed);
    }

    IEnumerator wander()
    {
        yield return movement.x = Random.Range(-5f, 5f);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
