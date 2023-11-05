using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
            other.gameObject.GetComponent<Enemy>().Damage();
        if (other.tag == "Player")
            other.gameObject.GetComponent<PlayerController>().Damage(damage);
        Destroy(this.gameObject);
    }
}
