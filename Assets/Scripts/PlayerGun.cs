using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public GameObject bullet;
    public Transform ShootPoint;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = dir;
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Attack();
        if (transform.rotation.z > -180 && transform.rotation.z <= 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        else
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }
    void Attack()
    {
        GameObject b = Instantiate(bullet, ShootPoint.position, Quaternion.Euler(0, 0, 0));
        b.GetComponent<Rigidbody2D>().AddForce(transform.up * speed, ForceMode2D.Force);
    }
}
