using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public float Speed;
    private Transform player;

    public bool isPlayer;
    public float checkRadiusPlayer;
    public Transform radiusAttackPos;

    public LayerMask whatIsPlayer;

    private Rigidbody2D rb;

    private Animator anim;

    public int hp;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isPlayer = Physics2D.OverlapCircle(radiusAttackPos.position, checkRadiusPlayer, whatIsPlayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(radiusAttackPos.position, checkRadiusPlayer);
    }

    private void FixedUpdate()
    {
        if (isPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);
            
        }

        if (player.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else 
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    public void Damage()
    {
        hp--;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
