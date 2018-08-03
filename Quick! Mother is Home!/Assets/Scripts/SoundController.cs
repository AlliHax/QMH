using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoundController : MonoBehaviour {
    public static SoundController instance = null;
    public float musicVolume = 1f;
    public Slider volumeSlider;
    public float lastSetVolume = 1;
    public AudioClip mainGameMusic;
    public AudioSource soundManager;

    void Awake()
    {
        soundManager.clip = mainGameMusic;
        soundManager.Play();
    }
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        soundManager.GetComponent<AudioSource>().volume = musicVolume;
    }

    public void SetVolume(float volume){
        Debug.Log(volume);
        musicVolume = volume;
        lastSetVolume = volume;
    }
}
