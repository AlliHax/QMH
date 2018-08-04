using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterDuster : MonoBehaviour {
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
        managerControllerScript.showDescriptionWindow = true;
        managerControllerScript.viewingDusterUpgradeDescription = true;
        managerControllerScript.descriptionTitle.text = "Swifty Duster";
        managerControllerScript.descriptionPriceText.text = "$150";
        managerControllerScript.descriptionText.text = "Get those hard to reach \nplaces!";
        managerControllerScript.popupWindowOpen = true;
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
