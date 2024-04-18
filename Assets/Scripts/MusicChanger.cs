using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    GameObject musicPlayer;
    public bool isCutscene;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("music " + PlayerPrefs.GetFloat("MusicVolume"));
        Debug.Log("sfx " + PlayerPrefs.GetFloat("SFXVolume"));
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        musicPlayer = objs[0];
        if(isCutscene)
            musicPlayer.GetComponent<Music>().Cutscene();
        else
            musicPlayer.GetComponent<Music>().Level();
    }
}
