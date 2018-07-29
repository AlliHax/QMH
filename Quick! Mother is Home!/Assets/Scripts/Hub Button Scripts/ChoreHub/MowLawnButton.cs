using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MowLawnButton : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    void OnMouseDown () {
        if (managerControllerScript.mowerUpgrade == false)
        {
            if (managerControllerScript.responsibilityLevel >= 25)
            {
                managerControllerScript.totalChores = managerControllerScript.totalChores + 1;
                managerControllerScript.mowerUpgrade = true;
            }
            else
            {
                managerControllerScript.showChoreUpgradeHud = false;
                managerControllerScript.displayNotResponsible = true;
            }
        }
    }
}

