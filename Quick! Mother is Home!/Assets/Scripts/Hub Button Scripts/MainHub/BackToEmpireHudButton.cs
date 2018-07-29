using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToEmpireHudButton : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    private void OnMouseDown()
    {
        managerControllerScript.showLemonadeHud = false;
        managerControllerScript.showEmpireHud = true;
    }
}
