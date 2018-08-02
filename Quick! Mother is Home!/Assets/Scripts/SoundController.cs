using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoundController : MonoBehaviour {
    public static SoundController instance = null;
    public GameObject menuMusicPlayer;
    public float musicVolume = 1f;
    public Slider volumeSlider;
    public float lastSetVolume = 1;

    void Awake()
    {
      
    }
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        menuMusicPlayer.GetComponent<AudioSource>().volume = musicVolume;
    }

    public void SetVolume(float volume){
        Debug.Log(volume);
        musicVolume = volume;
        lastSetVolume = volume;
    }
}
