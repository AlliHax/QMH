using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSponge : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }
    private void Update()
    {
        CheckForPopups();
    }

    void OnMouseDown()
    {
            managerControllerScript.showDescriptionWindow = true;
            managerControllerScript.viewingSpongeUpgradeDescription = true;
            managerControllerScript.descriptionTitle.text = "Magic Sponge";
            managerControllerScript.descriptionPriceText.text = "$40";
            managerControllerScript.descriptionText.text = "This is the best sponge EVER!";
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
