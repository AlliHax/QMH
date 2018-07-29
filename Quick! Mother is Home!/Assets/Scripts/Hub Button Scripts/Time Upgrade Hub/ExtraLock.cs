using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLock : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    void OnMouseDown()
    {
        managerControllerScript.popupWindowOpen = true;
        managerControllerScript.viewingExtraLockUpgradeDescription = true;
        managerControllerScript.descriptionTitle.text = "Extra Lock";
        managerControllerScript.descriptionPriceText.text = "$100";
        managerControllerScript.descriptionText.text = "Unlocking this lock\n takes mom longer!";
        managerControllerScript.showDescriptionWindow = true;
    }
}
