using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementus : MonoBehaviour
{
    public void LoadLevel(string name)
    {
        switch (name)
        {
            case "Cutscene0":
                LoadLvl1();
                break;
            case "Cutscene1":
                LoadLvl2();
                break;
            case "Cutscene2":
                LoadLvl3();
                break;
            case "Cutscene3":
                LoadLvl4();
                break;
            case "Cutscene4":
                Finish();
                break;
        }
    }

    public void LoadLvl1()
    {
        PlayerPrefs.SetFloat("Speed", 1);
        PlayerPrefs.SetFloat("BulletSpeed", 1);
        PlayerPrefs.SetInt("BulletCount", 1);
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
