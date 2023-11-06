using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject bullet;
    public Transform ShootPoint;
    public float speed;
    public float speedM = 1;

    public int bulletCount = 1;

    public float offset;

    private Transform player;

    public bool isPlayer;
    public float checkRadiusPlayer;
    public Transform radiusAttackPos;

    public LayerMask whatIsPlayer;

    private float timeBtwShots;
    public float startTimeBtwShots;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        isPlayer = Physics2D.OverlapCircle(radiusAttackPos.position, checkRadiusPlayer, whatIsPlayer);

        if (isPlayer)
        {
            Vector3 difference = player.transform.position - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

            if (timeBtwShots <= 0)
            {
                GameObject b = Instantiate(bullet, ShootPoint.position, transform.rotation);
                b.GetComponent<Rigidbody2D>().AddForce(transform.right * speed * speedM, ForceMode2D.Force);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(radiusAttackPos.position, checkRadiusPlayer);
    }
}
