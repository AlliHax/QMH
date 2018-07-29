using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockChoreSlot4 : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    // Use this for initialization
    void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    private void OnMouseDown()
    {
        managerControllerScript.choreSlot4UpgradeUnlocked = true;
        managerControllerScript.choreSlot3UpgradeUnlocked = false;
    }
}
