using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToStartMenuButton : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;
    // Use this for initialization
    void Start () {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    public void OnMouseDown()
    {
        managerControllerScript.showStartMenu = true;
        managerControllerScript.showMainHud = false;
        managerControllerScript.showCreditsScreen = false;
    }
}
