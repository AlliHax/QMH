using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpOkayButton : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    void OnMouseDown () {
        managerControllerScript.showLevelUpWindow = false;
        managerControllerScript.leveledUp = false;
        managerControllerScript.showOverview = true;
    }
}
