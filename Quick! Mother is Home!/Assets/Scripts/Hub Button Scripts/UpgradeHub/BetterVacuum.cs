using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterVacuum : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    void OnMouseDown()
    {
        if (managerControllerScript.betterVacuumActivated == false)
        {
            if (managerControllerScript.playerSavings >= 160)
            {
                managerControllerScript.playerSavings = managerControllerScript.playerSavings - 160;
                managerControllerScript.betterVacuumActivated = true;
                Debug.Log("Better Vaccum Added");
            }
            else
            {
                managerControllerScript.displayNotEnoughMoney = true;
            }
        }
    }
}
