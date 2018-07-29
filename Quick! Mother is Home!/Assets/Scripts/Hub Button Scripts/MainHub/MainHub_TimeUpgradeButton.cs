using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHub_TimeUpgradeButton : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    void OnMouseDown()
    {
        managerControllerScript.showEmpireHud = true;
    }
}
