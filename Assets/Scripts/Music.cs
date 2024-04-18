using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UIElements.Experimental;

public class Music : MonoBehaviour
{
    public AudioSource dialogueSource;
    public AudioMixer MusicMixer;
    public AudioSource fightSource;
    // Start is called before the first frame update
    
    void Start()
    {
        float value;
        MusicMixer.GetFloat("Music", out value);
        value += 80;
        value /= 80;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);

        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            dialogueSource.volume = value;
            fightSource.volume = 0;
        }
    }
    public void Level()
    {
        StopAllCoroutines();
        StartCoroutine("fight");
    }
    public void Cutscene()
    {
        StopAllCoroutines();
        StartCoroutine("dialogue");
    }

    IEnumerator dialogue()
    {
        float value;
        MusicMixer.GetFloat("Music", out value);
        value += 80;
        value /= 80;
        if (dialogueSource.volume < value)
            dialogueSource.volume += 0.07f;
        if (fightSource.volume > 0)
            fightSource.volume -= 0.07f;
        yield return new WaitForSeconds(0.1f);
        StartCoroutine("dialogue");
    }
    IEnumerator fight()
    {
        float value;
        MusicMixer.GetFloat("Music", out value);
        value += 80;
        value /= 80;
        if (dialogueSource.volume > 0)
            dialogueSource.volume -= 0.07f;
        if (fightSource.volume < value)
            fightSource.volume += 0.07f;
        yield return new WaitForSeconds(0.1f);
        StartCoroutine("fight");
    }
}
