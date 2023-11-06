using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    GameObject player;
    public GameObject gun1, gun2, gun3, gun4, gun5;
    public float speed;
    public float speedM = 1;
    public int bulletCount = 1;
    AudioSource source;
    public AudioClip clip;

    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        player = transform.parent.gameObject;
        speedM = PlayerPrefs.GetFloat("BulletSpeed", 1);
        bulletCount = PlayerPrefs.GetInt("BulletCount", 1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Attack();
    }

    void FixedUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        dir.Normalize();
        float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        if (rotZ < -90 || rotZ > 90)
        {
            if (player.transform.eulerAngles.y == 0)
                transform.localRotation = Quaternion.Euler(180, 0, -rotZ);
            else if (player.transform.eulerAngles.y == 180)
                transform.localRotation = Quaternion.Euler(180, 180, -rotZ);
        }
    }
    void Attack()
    {
        source.PlayOneShot(clip);
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
