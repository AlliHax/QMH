using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpireUpgradeInfoButtons : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    private void OnMouseDown()
    {
        managerControllerScript.showEmpireUpgradeDescriptionWindow = true;
        managerControllerScript.hideEmpireUpgradeCounts = true;
        if (gameObject.name == "flavor_infomark_Button")
        {
            managerControllerScript.empireDescriptionTitleText.text = ("Add Another Flavor!");
            managerControllerScript.empireDescriptionBodyText.text = ("Upgrade your lemonade stands with\n a new unique flavor!");
        }
    }
}
