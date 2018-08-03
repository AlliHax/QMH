using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustingMiniGameManager : MonoBehaviour {
    public GameObject duster;
    public int distance;
    public AudioClip brushingSound;
    public AudioSource dusterAudioSource;
    // Use this for initialization

    void Start()
    {
        dusterAudioSource.clip = brushingSound;
    }

    // Update is called once per frame
    void OnMouseDrag()
    {
        if (!dusterAudioSource.isPlaying)
        {
            dusterAudioSource.Play();
        }
        duster.SetActive(true);
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        duster.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void OnMouseUp()
    {
        duster.SetActive(false);
    }
}
