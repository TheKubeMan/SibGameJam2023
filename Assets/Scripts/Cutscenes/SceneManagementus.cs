using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementus : MonoBehaviour
{
    public void LoadLvl1()
    {
        PlayerPrefs.SetInt("Buff", 0);
        SceneManager.LoadScene("Level1");
    }
    public void LoadLvl2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void LoadLvl3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void LoadLvl4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void Finish()
    {
        Application.Quit();
    }
}
