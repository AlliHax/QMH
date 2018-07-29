using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetWasteButton : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }
 
    void OnMouseDown () {
        if (managerControllerScript.wasteUpgrade == false)
        {
            if (managerControllerScript.responsibilityLevel >= 15)
            {
                managerControllerScript.totalChores = managerControllerScript.totalChores + 1;
                managerControllerScript.wasteUpgrade = true;
            }
            else
            {
                managerControllerScript.showChoreUpgradeHud = false;
                managerControllerScript.displayNotResponsible = true;
            }
        }
    }
}
