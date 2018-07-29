using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitChoreDescriptionButton : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;
    // Use this for initialization
    void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnMouseDown()
    {
        managerControllerScript.viewChoreDescriptionWindow = false;
        managerControllerScript.viewingDishChoreDescription = false;
        managerControllerScript.viewingGarbageChoreDescription = false;
        managerControllerScript.viewingSweepingChoreDescription = false;
        managerControllerScript.popupWindowOpen = false;
    }
}
