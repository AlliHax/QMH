using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionExitButton : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;
    // Use this for initialization
    void Start () {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    private void OnMouseDown()
    {
        managerControllerScript.showDescriptionWindow = false;
        managerControllerScript.viewingSpongeUpgradeDescription = false;
        managerControllerScript.viewingBroomUpgradeDescription = false;
        managerControllerScript.viewingDusterUpgradeDescription = false;
        managerControllerScript.viewingGarbageUpgradeDescription = false;
        managerControllerScript.funnyDescriptionTextObject.SetActive(false);
        managerControllerScript.popupWindowOpen = false;

    }
}
