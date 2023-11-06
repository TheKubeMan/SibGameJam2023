using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startgame : MonoBehaviour
{
   public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quite()
    {
        Application.Quit();
    }
}
