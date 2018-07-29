using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooperScooper : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    void OnMouseDown()
    {
        if (managerControllerScript.pooperScooperActivated == false)
        {
            if (managerControllerScript.playerSavings >= 180)
            {
                managerControllerScript.playerSavings = managerControllerScript.playerSavings - 180;
                managerControllerScript.pooperScooperActivated = true;
                Debug.Log("PooperScooper Added");
            }
            else
            {
                managerControllerScript.displayNotEnoughMoney = true;
            }
        }
    }
}
