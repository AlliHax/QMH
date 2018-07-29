using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumButton : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }
    void OnMouseDown () {
        if (managerControllerScript.vacuumUpgrade == false)
        {
            if (managerControllerScript.responsibilityLevel >= 12)
            {
                managerControllerScript.vacuumUpgrade = true;
            }
            else
            {
                managerControllerScript.showChoreUpgradeHud = false;
                managerControllerScript.displayNotResponsible = true;
            }
        }
    }
}
