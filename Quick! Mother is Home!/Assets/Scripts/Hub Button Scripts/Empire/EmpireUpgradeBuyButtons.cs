using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpireUpgradeBuyButtons : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;


    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
        if (managerControllerScript.notFirstTimeRun == false)
        {
            managerControllerScript.flavorUpgradePrice = 50;
        }
    }
    // Update is called once per frame
    private void OnMouseDown()
    {
        if(gameObject.name == "flavor_Buy_Button")
        {
            if (managerControllerScript.playerSavings >= managerControllerScript.flavorUpgradePrice)
            {
                managerControllerScript.playerSavings = managerControllerScript.playerSavings - managerControllerScript.flavorUpgradePrice;
                managerControllerScript.flavorLemonadeUpgradeCount = managerControllerScript.flavorLemonadeUpgradeCount + 1;
                managerControllerScript.lemonadeRevenue = managerControllerScript.lemonadeRevenue + (managerControllerScript.flavorLemonadeUpgradeCount * 3);
                managerControllerScript.flavorUpgradePrice = managerControllerScript.flavorUpgradePrice + 50;
            }
        }
    }
}
