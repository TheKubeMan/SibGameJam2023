using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public float Speed;
    public float speedM = 1;
    private Transform player;

    public bool isPlayer;
    public float checkRadiusPlayer;
    public Transform radiusAttackPos;

    public LayerMask whatIsPlayer;

    private Rigidbody2D rb;

    private Animator anim;

    public int hp;

    public GameObject d1, d2, d3, d4, d5, d6;
    GameObject drop;
    public int type;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();

        int randomNumber2 = Random.Range(1, 101);
        if (randomNumber2 >= 1 && randomNumber2 < 31)
        {
            type = 1;
        }
        if (randomNumber2 >= 31 && randomNumber2 < 56)
        {
            type = 2;
        }
        if (randomNumber2 >= 56 && randomNumber2 < 76)
        {
            type = 3;
        }
        if (randomNumber2 >= 76 && randomNumber2 < 91)
        {
            type = 4;
        }
        if (randomNumber2 >= 91 && randomNumber2 < 101)
        {
            type = 5;
        }

        gameObject.GetComponent<EnemyBuffs>().type = type;
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
            transform.position = Vector2.MoveTowards(transform.position, player.position, Speed * speedM * Time.deltaTime);
            
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
            EnemyDrop();
            Destroy(gameObject);
        }
    }

    public void EnemyDrop()
    {
        int randomNumber = Random.Range(1, 4);
        if(randomNumber == 1)
        {
            int randomNumber2 = Random.Range(1, 101);
            if (randomNumber2 >= 1 && randomNumber2 < 31)
            {
                Instantiate(d1, transform.position, Quaternion.Euler(0, 0, 0));
            }
            if (randomNumber2 >= 31 && randomNumber2 < 56)
            {
                Instantiate(d2, transform.position, Quaternion.Euler(0, 0, 0));
            }
            if (randomNumber2 >= 56 && randomNumber2 < 76)
            {
                Instantiate(d3, transform.position, Quaternion.Euler(0, 0, 0));
            }
            if (randomNumber2 >= 76 && randomNumber2 < 91)
            {
                Instantiate(d4, transform.position, Quaternion.Euler(0, 0, 0));
            }
            if (randomNumber2 >= 91 && randomNumber2 < 101)
            {
                Instantiate(d5, transform.position, Quaternion.Euler(0, 0, 0));
            }
        }
        else
        {
            int randomNumber3 = Random.Range(1, 11);
            if(randomNumber3 == 1)
            {
                Instantiate(d6, transform.position, Quaternion.Euler(0, 0, 0));
            }
        }
    }
}
