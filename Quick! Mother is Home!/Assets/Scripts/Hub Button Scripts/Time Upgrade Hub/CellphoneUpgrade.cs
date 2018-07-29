using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellphoneUpgrade : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }
    void OnMouseDown () {
        if (managerControllerScript.cellphoneActivated == false)
        {
            if (managerControllerScript.playerSavings >= 400)
            {

                managerControllerScript.playerSavings = managerControllerScript.playerSavings - 400;
                managerControllerScript.cellphoneActivated = true;
                Debug.Log("New CellPhone Added");
            }
            else
            {
                managerControllerScript.displayNotEnoughMoney = true;
            }
        }
    }
}

