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
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject); 
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
