using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveOptionsMusic : MonoBehaviour
{
    private AudioSource audioSrc;
    private float musicVolume = 0.5f;
    public Slider Musicslider;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = musicVolume;
    }

    public void LoadVolume()
    {
        Musicslider.value = PlayerPrefs.GetFloat("musicVolume");

        SetMusicVolume();
    }

    public void SetMusicVolume()
    {
        musicVolume = Musicslider.value;
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
    }
}
