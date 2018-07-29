using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedsButton : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    void OnMouseDown () {
        if (managerControllerScript.backyardWeedsUpgrade == false)
        {
            if (managerControllerScript.responsibilityLevel >= 20)
            {
                managerControllerScript.totalChores = managerControllerScript.totalChores + 1;
                managerControllerScript.backyardWeedsUpgrade = true;
            }
            else
            {
                managerControllerScript.showChoreUpgradeHud = false;
                managerControllerScript.displayNotResponsible = true;
            }
        }
    }
}
