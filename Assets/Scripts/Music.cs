using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public AudioSource dialogueSource;
    public AudioSource fightSource;
    // Start is called before the first frame update
    
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);

        StopAllCoroutines();
        if(SceneManager.GetActiveScene().name == "Cutscene0" || SceneManager.GetActiveScene().name == "Cutscene1" || SceneManager.GetActiveScene().name == "Cutscene2" || SceneManager.GetActiveScene().name == "Cutscene3" || SceneManager.GetActiveScene().name == "Cutscene4")
            StartCoroutine("dialogue");
        else if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            dialogueSource.volume = 1;
            fightSource.volume = 0;
        }
        else
            StartCoroutine("fight");
    }

    IEnumerator dialogue()
    {
        if (dialogueSource.volume < 1)
            dialogueSource.volume += 0.05f;
        if (fightSource.volume > 0)
            fightSource.volume -= 0.05f;
        yield return new WaitForSeconds(0.1f);
    }
    IEnumerator fight()
    {
        if (dialogueSource.volume > 0)
            dialogueSource.volume -= 0.05f;
        if (fightSource.volume < 1)
            fightSource.volume += 0.05f;
        yield return new WaitForSeconds(0.1f);
    }
}
