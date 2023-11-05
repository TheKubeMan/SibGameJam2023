using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Bullet : MonoBehaviour
{
    public bool IsPlayerBullet;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
            other.gameObject.GetComponent<Enemy>().Damage();
        if (other.tag == "Player")
            other.gameObject.GetComponent<PlayerController>().Damage();
        if ((other.tag == "PBullet" && IsPlayerBullet) || (other.tag == "EBullet" && !IsPlayerBullet))
        {}
        else
            Destroy(this.gameObject);        
    }
}
