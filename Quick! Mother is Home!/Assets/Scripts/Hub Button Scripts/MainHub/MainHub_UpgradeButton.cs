using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHub_UpgradeButton : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    void OnMouseDown()
    {
        managerControllerScript.showToolUpgradeHud = true;
    }
}
