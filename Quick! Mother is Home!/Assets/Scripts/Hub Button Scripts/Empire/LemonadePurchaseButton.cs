using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonadePurchaseButton : MonoBehaviour {

    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    private void OnMouseDown()
    {
        if (managerControllerScript.playerSavings >= 100)
        {

            managerControllerScript.playerSavings = managerControllerScript.playerSavings - 100;
            managerControllerScript.lemonadePurchased = true;
            managerControllerScript.lemonadeRevenue = 5;
        }
    }
}
