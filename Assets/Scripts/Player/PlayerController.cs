using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Vector2 move;
    public Rigidbody2D rb;
	public SpriteRenderer sr;
	public Animator a;
	public float speed;
    public float speedM;
    int maxHP;
    int hp;
    AudioSource AS;
    public AudioClip hit;
    public Text hpText;
    bool facingRight = true;
    public GameObject deathEffect;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
		sr = this.gameObject.GetComponent<SpriteRenderer>();
		a = this.gameObject.GetComponent<Animator>();
        AS = gameObject.GetComponent<AudioSource>();
        maxHP = PlayerPrefs.GetInt("maxHP", 3);
        hp = maxHP;
        hpText.text = "HP: " + hp.ToString();
        speedM = PlayerPrefs.GetFloat("Speed", 1);
    }

    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
		move.y = Input.GetAxisRaw("Vertical");
		a.SetFloat("Horizontal", rb.velocity.x);
		a.SetFloat("Vertical", rb.velocity.y);
		a.SetFloat("Speed", move.sqrMagnitude);
		if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
		{
			a.SetFloat("LastH", rb.velocity.x);
			a.SetFloat("LastV", rb.velocity.y);
		}

        if(hp <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        rb.velocity = move * speed * speedM;
        if (move.x > 0 && !facingRight) {
				Flip ();
			}
			else if (move.x < 0 && facingRight) {
				Flip ();
			}
    }
    public void Damage()
    {
        hp--;
        hpText.text = "HP: " + hp.ToString();
        AS.PlayOneShot(hit);
    }
    public void Restore()
    {
        if (maxHP < 10)
            maxHP++;
        hp++;
        PlayerPrefs.SetInt("maxHP", maxHP);
        hpText.text = "HP: " + hp.ToString();
    }

    void Flip(){
        if (transform.rotation.y == 0)
		    transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
        else
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
		facingRight = !facingRight;
	}
}
