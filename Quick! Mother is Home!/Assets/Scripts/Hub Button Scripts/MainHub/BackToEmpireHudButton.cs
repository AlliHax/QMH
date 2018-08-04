using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToEmpireHudButton : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;
    public AudioClip buttonPushedSound;
    public AudioSource soundEffectSource;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    private void OnMouseDown()
    {
        soundEffectSource.clip = buttonPushedSound;
        soundEffectSource.Play();
        managerControllerScript.showLemonadeHud = false;
        managerControllerScript.showEmpireHud = true;
    }
}
