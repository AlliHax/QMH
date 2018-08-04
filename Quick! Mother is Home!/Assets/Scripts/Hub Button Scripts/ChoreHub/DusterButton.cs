using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusterButton : MonoBehaviour
{
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
        soundEffectSource.Play();
        managerControllerScript.viewingDustingChoreDescription = true;
        managerControllerScript.choreDescriptionTitle.text = "Dusting";
        managerControllerScript.choreDescriptionText.text = "Dust is the enemy!\n Destroy all the dust!";
        managerControllerScript.choreDescriptionLevelRequirement.text = "RL: 3 Required";
        managerControllerScript.popupWindowOpen = true;

        managerControllerScript.viewChoreDescriptionWindow = true;
    }
}
