using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHub_TimeUpgradeButton : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;
    public AudioClip buttonPushedSound;
    public AudioSource soundEffectSource;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
        soundEffectSource.clip = buttonPushedSound;
    }

    void OnMouseDown()
    {
        managerControllerScript.showEmpireHud = true;
        soundEffectSource.Play();
    }
}
