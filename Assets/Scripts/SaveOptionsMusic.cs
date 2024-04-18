using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SaveOptionsMusic : MonoBehaviour
{
    [SerializeField] private Slider Musicslider;
    [SerializeField] private Slider SFXslider;
    [SerializeField] private AudioMixer myMixer;

    // Start is called before the first frame update
    void Start()
    {
        SetMusicVolume();

        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadVolume()
    {
        Musicslider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXslider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetMusicVolume();
        SetSFXVolume();
    }

    public void SetMusicVolume()
    {
        float musicVolume = Musicslider.value;
        myMixer.SetFloat("music", Mathf.Log10(musicVolume)*20);
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
    }

    public void SetSFXVolume()
    {
        float musicVolume = SFXslider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(musicVolume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", musicVolume);
    }
}
