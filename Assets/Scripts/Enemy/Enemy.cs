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

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private float startTearsUp; //Начальная скорострельность
    [SerializeField] private float distance;
    [SerializeField] private float tearsUp; //Скорострельность
    [SerializeField] private bool facingRight = true;
    private Animator anim;

    [SerializeField] private GameObject rotate;
    [SerializeField] private float offset;
    private Vector2 position;

    [SerializeField] private GameObject gun;

    public GunType gunType;
    public enum GunType {Default, Enemy}

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

        Vector3 difference = player.transform.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
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
            if (tearsUp <= 0)
            {
                Instantiate(bullet, shotPoint.position, rotate.transform.rotation);
                tearsUp = startTearsUp;
            }
            else
            {
                tearsUp -= Time.deltaTime;
            }

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

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
}
