using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int currentHealth = 25;
    public int maxHealth = 25;

    public bool playerNear;
    private bool isAttacking = false;

    public GameObject playerObj;
    public GameObject enemy;

    GameObject thePlayer;
    public Player player;

    private Rigidbody2D rb2d;
    private Animator anim;

    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        thePlayer = GameObject.Find("Player");
        player = thePlayer.GetComponent<Player>();
}

    private void Update()
    {
        if (player.enemyDead == true)
        {
            player.thisOne.SetActive(false);
            player.enemyHealth = 25;
        }
    }

}

