using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonadeInfoButton : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;
    public AudioClip buttonPushedSound;
    public AudioSource soundEffectSource;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
        soundEffectSource.clip = buttonPushedSound;
    }
    private void OnMouseDown()
    {
        managerControllerScript.showLemonadeHud = true;
        soundEffectSource.Play();
    }
}
