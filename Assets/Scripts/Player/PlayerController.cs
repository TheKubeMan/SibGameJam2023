using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Vector2 move;
    public Rigidbody2D rb;
	public SpriteRenderer sr;
	public Animator a;
	public float speed;
    public float speedM = 1;
    int maxHP;
    int hp;
    AudioSource AS;
    public AudioClip hit;
    public Text hpText;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
		sr = this.gameObject.GetComponent<SpriteRenderer>();
		a = this.gameObject.GetComponent<Animator>();
        AS = gameObject.GetComponent<AudioSource>();
        maxHP = PlayerPrefs.GetInt("maxHP", 3);
        hp = maxHP;
        hpText.text = "HP: " + hp.ToString();
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
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        rb.velocity = move * speed * speedM;
    }
    public void Damage()
    {
        hp--;
        hpText.text = "HP: " + hp.ToString();
        AS.PlayOneShot(hit);
    }
    public void Restore()
    {
        maxHP++;
        hp++;
        PlayerPrefs.SetInt("maxHP", maxHP);
        hpText.text = "HP: " + hp.ToString();
    }
}
