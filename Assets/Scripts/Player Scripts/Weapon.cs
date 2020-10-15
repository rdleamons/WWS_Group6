using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireballPrefab;
    public Player player;
    public HealthBar healthBar;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") | Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        int fate = Random.Range(1, 11);

        if (fate <= 5)
            Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
        else if (5 < fate & fate <= 7)
        {
            player.currentHealth -= 1;
            healthBar.SetHealth(player.currentHealth);
        }
        else if (7 < fate & fate <= 9)
        {
            player.currentHealth += 2;
            healthBar.SetHealth(player.currentHealth);
        }
        else if (fate == 10)
        {
            chicken(player.playerRenderer);
            Debug.Log("Chicken");
        }
    }

    IEnumerator chicken(SpriteRenderer spriteRenderer)
    {
        player.playerRenderer.material.color = Color.red;
        yield return new WaitForSeconds(1.0f);
        player.playerRenderer.material.color = Color.white;
    }
}
