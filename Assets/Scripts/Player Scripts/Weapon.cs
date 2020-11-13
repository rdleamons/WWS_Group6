using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireballPrefab;
    public Player player;
    public HealthBar healthBar;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") | Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("isAttacking", true);
            Shoot();
        }

        if(Input.GetButtonUp("Fire1") | Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("isAttacking", false);
        }
    }

    void Shoot()
    {
        int fate = Random.Range(1, 11);

        if (fate <= 5)
            Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
        else if (5 < fate & fate <= 6)
        {
            player.currentHealth -= 5;
            healthBar.SetHealth(player.currentHealth);
        }
        else if (6 < fate & fate <= 9)
        {
            player.currentHealth += 5;
            healthBar.SetHealth(player.currentHealth);
        }
        else if (fate == 10)
        {
            StartCoroutine(chicken(player.playerRenderer));
        }
    }

    IEnumerator chicken(SpriteRenderer spriteRenderer)
    {
        anim.SetBool("missfire", true);
        yield return new WaitForSeconds(1.0f);
        anim.SetBool("missfire", false);
    }
}
