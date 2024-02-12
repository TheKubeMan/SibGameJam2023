using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startgame : MonoBehaviour
{
   public void Play()
    {
        SceneManager.LoadScene("Cutscene0");
    }

    public void Quite()
    {
        Application.Quit();
    }
}
