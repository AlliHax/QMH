using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletButton : MonoBehaviour
{
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    void OnMouseDown()
    {
        if (managerControllerScript.toiletUpgrade == false)
        {
            if (managerControllerScript.responsibilityLevel >= 5)
            {
                managerControllerScript.totalChores = managerControllerScript.totalChores + 1;
                managerControllerScript.toiletUpgrade = true;
            }
            else
            {
                managerControllerScript.showChoreUpgradeHud = false;
                managerControllerScript.displayNotResponsible = true;
            }
        }
    }
}
