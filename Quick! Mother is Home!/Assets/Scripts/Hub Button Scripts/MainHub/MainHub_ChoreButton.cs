using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHub_ChoreButton : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    void OnMouseDown()
    {
        managerControllerScript.showChoreUpgradeHud = true;
    }
}
