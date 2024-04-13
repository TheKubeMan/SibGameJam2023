using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeChanger : MonoBehaviour
{
    public AudioMixer MusicMixer; 
	public AudioMixer SFXMixer; 
	public Text MusicValue, MusicValue1;
	public Text SFXValue, SFXValue1;
	float MusicFloat;
	float SFXFloat;
	float MusicVol;
	float SFXVol;
	public Slider MusicSlider;
	public Slider SFXSlider;

	void Start(){
		MusicVol = PlayerPrefs.GetFloat("MusicVolume");
		MusicMixer.SetFloat("Music", MusicVol * 0.8f - 80);
		MusicSlider.value = MusicVol;
		MusicFloat = MusicVol;
		MusicValue.text = MusicFloat.ToString();
		MusicValue1.text = MusicFloat.ToString();

		SFXVol = PlayerPrefs.GetFloat("SFXVolume");
		SFXMixer.SetFloat("SFX", SFXVol * 0.8f - 80);
		SFXSlider.value = SFXVol;
		SFXFloat = SFXVol;
		SFXValue.text = SFXFloat.ToString();
		SFXValue1.text = SFXFloat.ToString();
	}

	public void MusicVolumeChange(float MusicVolume){
		PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
		MusicMixer.SetFloat("Music", MusicVolume * 0.8f - 80);
		MusicFloat = MusicVolume;
		MusicValue.text = MusicFloat.ToString();
		MusicValue1.text = MusicFloat.ToString();
	}

	public void SFXVolumeChange(float SFXVolume){
		PlayerPrefs.SetFloat("SFXVolume", SFXVolume);
		SFXMixer.SetFloat("SFX", SFXVolume * 0.8f - 80);
		SFXFloat = SFXVolume;
		SFXValue.text = SFXFloat.ToString();
		SFXValue1.text = SFXFloat.ToString();
	}
}
