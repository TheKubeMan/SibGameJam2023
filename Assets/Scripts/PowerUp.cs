using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerUp : MonoBehaviour
{
    public int type, group;
    void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level1":
                group = 1;
                break;
            case "Level2":
                group = 2;
                break;
            case "Level3":
                group = 3;
                break;
            case "Level4":
                group = 3;
                break;
            default:
                group = 1;
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (type == 0)
                other.gameObject.GetComponent<PlayerController>().Restore();
            else
            {
                other.gameObject.GetComponent<PlayerController>().speedM = 1;
                other.gameObject.GetComponentInChildren<PlayerGun>().speedM = 1;
                other.gameObject.GetComponentInChildren<PlayerGun>().bulletCount = 1;
                
                switch (group)
                {
                    case 1:
                        switch (type)
                        {
                            case 1:
                                other.gameObject.GetComponent<PlayerController>().speedM = 1.25f;
                                break;
                            case 2:
                                other.gameObject.GetComponentInChildren<PlayerGun>().speedM = 1.25f;
                                break;
                            case 3:
                                other.gameObject.GetComponent<PlayerController>().speedM = 1.25f;
                                other.gameObject.GetComponentInChildren<PlayerGun>().speedM = 1.25f;
                                break;
                            case 4:
                                other.gameObject.GetComponentInChildren<PlayerGun>().bulletCount = 2;
                                break;
                            case 5:
                                other.gameObject.GetComponentInChildren<PlayerGun>().bulletCount = 2;
                                other.gameObject.GetComponent<PlayerController>().speedM = 1.25f;
                                break;
                        }
                        break;
                    case 2:
                        switch (type)
                        {
                            case 1:
                                other.gameObject.GetComponent<PlayerController>().speedM = 1.5f;
                                break;
                            case 2:
                                other.gameObject.GetComponentInChildren<PlayerGun>().speedM = 1.5f;
                                break;
                            case 3:
                                other.gameObject.GetComponent<PlayerController>().speedM = 1.5f;
                                other.gameObject.GetComponentInChildren<PlayerGun>().speedM = 1.5f;
                                break;
                            case 4:
                                other.gameObject.GetComponentInChildren<PlayerGun>().bulletCount = 3;
                                break;
                            case 5:
                                other.gameObject.GetComponentInChildren<PlayerGun>().bulletCount = 4;
                                other.gameObject.GetComponent<PlayerController>().speedM = 1.25f;
                                break;
                        }
                        break;
                    case 3:
                        switch (type)
                        {
                            case 1:
                                other.gameObject.GetComponent<PlayerController>().speedM = 1.75f;
                                break;
                            case 2:
                                other.gameObject.GetComponentInChildren<PlayerGun>().speedM = 1.75f;
                                break;
                            case 3:
                                other.gameObject.GetComponent<PlayerController>().speedM = 1.75f;
                                other.gameObject.GetComponentInChildren<PlayerGun>().speedM = 1.75f;
                                break;
                            case 4:
                                other.gameObject.GetComponentInChildren<PlayerGun>().bulletCount = 4;
                                other.gameObject.GetComponent<PlayerController>().speedM = 1.25f;
                                break;
                            case 5:
                                other.gameObject.GetComponentInChildren<PlayerGun>().bulletCount = 5;
                                other.gameObject.GetComponent<PlayerController>().speedM = 1.5f;
                                other.gameObject.GetComponentInChildren<PlayerGun>().speedM = 1.25f;
                                break;
                        }
                        break;
                }
            }
            PlayerPrefs.SetFloat("Speed", other.gameObject.GetComponent<PlayerController>().speedM);
            PlayerPrefs.SetFloat("BulletSpeed", other.gameObject.GetComponentInChildren<PlayerGun>().speedM);
            PlayerPrefs.SetInt("BulletCount", other.gameObject.GetComponentInChildren<PlayerGun>().bulletCount);
            PlayerPrefs.SetInt("Buff", type);
            Destroy(gameObject);
        }
    }
}
