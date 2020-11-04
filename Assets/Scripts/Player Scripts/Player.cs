using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int currentHealth = 0;
    public int maxHealth = 25;

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
        healthBar.SetHealth(maxHealth);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            enemy = col.GetComponent<Enemy>();
        }

        if(col.CompareTag("Killzone"))
        {
            die();
        }

        if(col.CompareTag("Gem"))
        {
            //You win!
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        StartCoroutine(flashDamage(playerRenderer));
        healthBar.SetHealth(currentHealth);
    }

    void die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator flashDamage(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.material.color = Color.red;
        yield return new WaitForSeconds(1.0f);
        spriteRenderer.material.color = Color.white;
    }
}
