using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public float speed;
    public float speedM = 1;
    public GameObject gun1, gun2, gun3, gun4, gun5;
    public int bulletCount = 1;

    public float offset;

    private Transform player;
    private Transform enemy;

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
        enemy = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void FixedUpdate()
    {
        isPlayer = Physics2D.OverlapCircle(radiusAttackPos.position, checkRadiusPlayer, whatIsPlayer);

        if (isPlayer)
        {
            Vector3 difference = player.transform.position - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

            if (timeBtwShots <= 0)
            {
                Attack();
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }

            if (rotZ < -90 || rotZ > 90)
            {
                if (enemy.eulerAngles.y == 0)
                    transform.localRotation = Quaternion.Euler(180, 0, -rotZ);
                else if (enemy.eulerAngles.y == 180)
                    transform.localRotation = Quaternion.Euler(180, 180, -rotZ);
            }
        }

        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(radiusAttackPos.position, checkRadiusPlayer);
    }

    void Attack()
    {
        switch (bulletCount)
        {
            case 1:
                gun1.GetComponent<GunShoot>().Attack(speed, speedM);
                break;
            case 2:
                gun2.GetComponent<GunShoot>().Attack(speed, speedM);
                gun3.GetComponent<GunShoot>().Attack(speed, speedM);
                break;
            case 3:
                gun1.GetComponent<GunShoot>().Attack(speed, speedM);
                gun2.GetComponent<GunShoot>().Attack(speed, speedM);
                gun3.GetComponent<GunShoot>().Attack(speed, speedM);
                break;
            case 4:
                gun2.GetComponent<GunShoot>().Attack(speed, speedM);
                gun3.GetComponent<GunShoot>().Attack(speed, speedM);
                gun4.GetComponent<GunShoot>().Attack(speed, speedM);
                gun5.GetComponent<GunShoot>().Attack(speed, speedM);
                break;
            case 5:
                gun1.GetComponent<GunShoot>().Attack(speed, speedM);
                gun2.GetComponent<GunShoot>().Attack(speed, speedM);
                gun3.GetComponent<GunShoot>().Attack(speed, speedM);
                gun4.GetComponent<GunShoot>().Attack(speed, speedM);
                gun5.GetComponent<GunShoot>().Attack(speed, speedM);
                break;
        }
    }
}
