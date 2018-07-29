using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoreSlot3Unlock : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    // Use this for initialization
    void Start () {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    private void OnMouseDown()
    {
        managerControllerScript.showDescriptionWindow = true;
        managerControllerScript.viewingChoreSlot3UpgradeDescription = true;
        managerControllerScript.descriptionTitle.text = "3rd Chore Slot";
        managerControllerScript.descriptionPriceText.text = "$200";
        managerControllerScript.descriptionText.text = "Unlocking this allows you\n to do one more chores\n Everday!";
        managerControllerScript.popupWindowOpen = true;
    }
}
