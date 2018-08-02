using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditButton : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;
    // Use this for initialization
    void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        managerControllerScript.showStartMenu = false;
        managerControllerScript.showCreditsScreen = true;
    }
		
	
}
