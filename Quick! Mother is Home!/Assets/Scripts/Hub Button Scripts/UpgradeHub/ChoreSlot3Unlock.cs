using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoreSlot3Unlock : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;
    public AudioClip buttonPushedSound;
    public AudioSource soundEffectSource;

    // Use this for initialization
    void Start () {
        managerControllerScript = manager.GetComponent<ManagerController>();
        soundEffectSource.clip = buttonPushedSound;
    }

    private void OnMouseDown()
    {
        soundEffectSource.Play();
        managerControllerScript.showDescriptionWindow = true;
        managerControllerScript.viewingChoreSlot3UpgradeDescription = true;
        managerControllerScript.descriptionTitle.text = "3rd Chore Slot";
        managerControllerScript.descriptionPriceText.text = "$200";
        managerControllerScript.descriptionText.text = "Unlocking this allows you\n to do one more chores\n Everday!";
        managerControllerScript.popupWindowOpen = true;
    }
}
