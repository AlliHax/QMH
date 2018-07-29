using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaundryButton : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }
    void OnMouseDown ()
    {
        if (managerControllerScript.washerUpgrade == false)
        {
            if (managerControllerScript.responsibilityLevel >= 10)
            {
                managerControllerScript.totalChores = managerControllerScript.totalChores + 1;
                managerControllerScript.washerUpgrade = true;
            }
            else
            {
                managerControllerScript.showChoreUpgradeHud = false;
                managerControllerScript.displayNotResponsible = true;
            }
        }
    }
}
