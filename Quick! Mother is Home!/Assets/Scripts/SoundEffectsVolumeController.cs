using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsVolumeController : MonoBehaviour {
    public static SoundController instance = null;
    public float musicVolume = 1f;
    public float lastSetVolume = 1;
    public AudioSource soundManager;
    // Update is called once per frame
    void Update()
    {
        soundManager.GetComponent<AudioSource>().volume = musicVolume;
    }
    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        musicVolume = volume;
        lastSetVolume = volume;
    }
}
