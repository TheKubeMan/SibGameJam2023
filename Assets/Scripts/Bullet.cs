using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.tag == "Enemy")
            //other.gameObject.GetComponent<Enemy>().Damage();
        //else if (other.tag == "Player)
            //other.gameObject.GetComponent<PlayerController>().Damage;
        Destroy(gameObject);
    }
}
