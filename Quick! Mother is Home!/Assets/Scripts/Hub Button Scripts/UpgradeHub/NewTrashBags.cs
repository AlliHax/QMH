using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTrashBags : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;
    public AudioClip buttonPushedSound;
    public AudioSource soundEffectSource;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
        soundEffectSource.clip = buttonPushedSound;
    }

    void Update()
    {
        CheckForPopups();
    }

    void OnMouseDown()
    {
        soundEffectSource.Play();
        managerControllerScript.viewingGarbageUpgradeDescription = true;
        managerControllerScript.descriptionTitle.text = "Nifty Bags";
        managerControllerScript.descriptionPriceText.text = "$200";
        managerControllerScript.descriptionText.text = "These bags are\n Nifty Nifty Nifty!";
        managerControllerScript.popupWindowOpen = true;

        managerControllerScript.showDescriptionWindow = true;
    }

    private void CheckForPopups()
    {
        if (managerControllerScript.popupWindowOpen == true)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
        else if (managerControllerScript.popupWindowOpen == false)
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }
}
