using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterDetergent : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    void OnMouseDown()
    {
        if (managerControllerScript.betterDetergentActivated == false)
        {
            if (managerControllerScript.playerSavings >= 140)
            {
                managerControllerScript.playerSavings = managerControllerScript.playerSavings - 140;
                managerControllerScript.betterDetergentActivated = true;
                Debug.Log("Better Detergent Added");
            }
            else
            {
                managerControllerScript.displayNotEnoughMoney = true;
            }
        }
    }
}
