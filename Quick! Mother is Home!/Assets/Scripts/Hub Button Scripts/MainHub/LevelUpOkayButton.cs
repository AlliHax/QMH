using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpOkayButton : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;
    public AudioClip buttonPushedSound;
    public AudioSource soundEffectSource;

    private void Start()
    {
        
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    void OnMouseDown () {
        soundEffectSource.clip = buttonPushedSound;
        soundEffectSource.Play();
        managerControllerScript.showLevelUpWindow = false;
        managerControllerScript.leveledUp = false;
        managerControllerScript.showOverview = true;
    }
}
