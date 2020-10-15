using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int attack;
    public int enemyAttack;

    public int currentHealth = 0;
    public int maxHealth = 50;
    public int enemyHealth = 10;
    public bool isAttacking = false;

    public bool enemyNear;
    public bool enemyDead;

    public GameObject thisOne;
    Enemy enemy;

    public HealthBar healthBar;

    private Rigidbody2D rb2d;
    public Animator anim;

    public SpriteRenderer playerRenderer;
    Color originalColor = Color.white;

    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            enemyNear = true;
            enemy = col.GetComponent<Enemy>();
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            enemyNear = false;
        }
    }

    private void Update()
    { 
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {
            die();
        }
    }

    void die()
    {
        Application.LoadLevel("Main");
    }

    IEnumerator Flasher(SpriteRenderer spriteRenderer)
    {
        playerRenderer.material.color = Color.red;
        yield return new WaitForSeconds(.1f);
        playerRenderer.material.color = originalColor;
    }
}
