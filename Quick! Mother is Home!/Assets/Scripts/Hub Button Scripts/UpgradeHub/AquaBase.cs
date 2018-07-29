using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquaBase : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    void OnMouseDown()
    {
        if (managerControllerScript.aquaBaseActivated == false)
        {
            if (managerControllerScript.playerSavings >= 120)
            {
                managerControllerScript.playerSavings = managerControllerScript.playerSavings - 120;
                managerControllerScript.aquaBaseActivated = true;
                Debug.Log("Aqua Base Added");
            }
            else
            {
                managerControllerScript.displayNotEnoughMoney = true;
            }
        }
    }
}
