using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBroom : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;
    public AudioClip buttonPushedSound;
    public AudioSource soundEffectSource;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
        soundEffectSource.clip = buttonPushedSound;
    }

    private void Update()
    {
        CheckForPopups();
    }

    void OnMouseDown()
    {
        soundEffectSource.Play();
        managerControllerScript.viewingBroomUpgradeDescription = true;
        managerControllerScript.descriptionTitle.text = "Nimbus 1000";
        managerControllerScript.descriptionPriceText.text = "$100";
        managerControllerScript.descriptionText.text = "Works like MAGIC* on floors!";
        managerControllerScript.funnyDescriptionText.text = "*Our company is not liable for any\n injuries from flying spontaneously";
        managerControllerScript.funnyDescriptionTextObject.SetActive(true);
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
