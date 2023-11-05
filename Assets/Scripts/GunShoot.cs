using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public GameObject bullet;
    public void Attack(float speed, float speedM)
    {
        GameObject b = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 0));
        b.GetComponent<Rigidbody2D>().AddForce(transform.right * speed * speedM, ForceMode2D.Force);
    }
}
