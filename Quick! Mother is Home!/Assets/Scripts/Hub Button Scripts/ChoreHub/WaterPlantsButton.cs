using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlantsButton : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    void OnMouseDown() {
        if (managerControllerScript.plantUpgrade == false)
        {
            if (managerControllerScript.responsibilityLevel >= 18)
            {
                managerControllerScript.totalChores = managerControllerScript.totalChores + 1;
                managerControllerScript.plantUpgrade = true;
            }
            else
            {
                managerControllerScript.showChoreUpgradeHud = false;
                managerControllerScript.displayNotResponsible = true;
            }
        }
    }
}
