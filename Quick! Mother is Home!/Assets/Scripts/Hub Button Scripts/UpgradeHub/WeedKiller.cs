using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedKiller : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    void OnMouseDown()
    {
        if (managerControllerScript.weedKillerActivated == false)
        {
            if (managerControllerScript.playerSavings >= 160)
            {
                managerControllerScript.playerSavings = managerControllerScript.playerSavings - 160;
                managerControllerScript.weedKillerActivated = true;
                Debug.Log("Weed Killer Added");
            }
            else
            {
                managerControllerScript.displayNotEnoughMoney = true;
            }
        }
    }
}
