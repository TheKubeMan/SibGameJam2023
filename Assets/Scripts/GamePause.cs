using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pause;
    public GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        gun.GetComponent<PlayerGun>().enabled = true;
    }

    public void Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        gun.GetComponent<PlayerGun>().enabled = false;
    }
}
