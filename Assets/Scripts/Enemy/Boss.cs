using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float Speed;
    public float speedM = 1;
    private Transform player;
    public LayerMask whatIsPlayer;
    public bool playerIsAlive = true;
    private Rigidbody2D rb;
    private Animator anim;
    public int health;
    public GameObject deathEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        anim.SetInteger("boss", 1);
    }

    private void FixedUpdate()
    {
        if (playerIsAlive)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, Speed * speedM * Time.deltaTime);

            if (player.transform.position.x > transform.position.x)
                transform.eulerAngles = new Vector3(0, 0, 0);
            else
                transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    public void DamageBoss()
    {
        health--;
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    } 
}
