using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 move;
    public Rigidbody2D rb;
	public SpriteRenderer sr;
	public Animator a;
	public float speed;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
		sr = this.gameObject.GetComponent<SpriteRenderer>();
		a = this.gameObject.GetComponent<Animator>();
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
    }
    void FixedUpdate()
    {
        rb.velocity = move * speed;
    }
}
