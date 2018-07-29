using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkieTalkies : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }
    void OnMouseDown()
    {
        if (managerControllerScript.walkieTalkieActivated == false)
        {
            if (managerControllerScript.playerSavings >= 300)
            {

                managerControllerScript.playerSavings = managerControllerScript.playerSavings - 300;
                managerControllerScript.walkieTalkieActivated = true;
                Debug.Log("Walkie Talkies Added");
            }
            else
            {
                managerControllerScript.displayNotEnoughMoney = true;
            }
        }
    }
}
