using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBuffs : MonoBehaviour
{
    public int type, group;

    // Start is called before the first frame update
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
            default:
                group = 1;
                break;
        }

        switch (group)
        {
            case 1:
                switch (type)
                {
                    case 1:
                        gameObject.GetComponent<Enemy>().speedM = 1.25f;
                        break;
                    case 2:
                        gameObject.GetComponentInChildren<EnemyGun>().speedM = 1.25f;
                        break;
                    case 3:
                        gameObject.GetComponent<Enemy>().speedM = 1.25f;
                        gameObject.GetComponentInChildren<EnemyGun>().speedM = 1.25f;
                        break;
                    case 4:
                        gameObject.GetComponentInChildren<EnemyGun>().bulletCount = 2;
                        break;
                    case 5:
                        gameObject.GetComponentInChildren<EnemyGun>().bulletCount = 2;
                        gameObject.GetComponent<Enemy>().speedM = 1.25f;
                        break;
                }
                break;
            case 2:
                switch (type)
                {
                    case 1:
                        gameObject.GetComponent<Enemy>().speedM = 1.5f;
                        break;
                    case 2:
                        gameObject.GetComponentInChildren<EnemyGun>().speedM = 1.5f;
                        break;
                    case 3:
                        gameObject.GetComponent<Enemy>().speedM = 1.5f;
                        gameObject.GetComponentInChildren<EnemyGun>().speedM = 1.5f;
                        break;
                    case 4:
                        gameObject.GetComponentInChildren<EnemyGun>().bulletCount = 3;
                        break;
                    case 5:
                        gameObject.GetComponentInChildren<EnemyGun>().bulletCount = 4;
                        gameObject.GetComponent<Enemy>().speedM = 1.25f;
                        break;
                }
                break;
            case 3:
                switch (type)
                {
                    case 1:
                        gameObject.GetComponent<Enemy>().speedM = 1.75f;
                        break;
                    case 2:
                        gameObject.GetComponentInChildren<EnemyGun>().speedM = 1.75f;
                        break;
                    case 3:
                        gameObject.GetComponent<Enemy>().speedM = 1.75f;
                        gameObject.GetComponentInChildren<EnemyGun>().speedM = 1.75f;
                        break;
                    case 4:
                        gameObject.GetComponentInChildren<EnemyGun>().bulletCount = 4;
                        gameObject.GetComponent<Enemy>().speedM = 1.25f;
                        break;
                    case 5:
                        gameObject.GetComponentInChildren<EnemyGun>().bulletCount = 5;
                        gameObject.GetComponent<Enemy>().speedM = 1.5f;
                        gameObject.GetComponentInChildren<EnemyGun>().speedM = 1.25f;
                        break;
                }
                break;
            }
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
