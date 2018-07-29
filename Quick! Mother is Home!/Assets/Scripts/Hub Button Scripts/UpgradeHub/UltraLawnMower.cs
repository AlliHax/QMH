using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltraLawnMower : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    void OnMouseDown()
    {
        if (managerControllerScript.ultraMowerActivated == false)
        {
            if (managerControllerScript.playerSavings >= 200)
            {
                managerControllerScript.playerSavings = managerControllerScript.playerSavings - 200;
                managerControllerScript.ultraMowerActivated = true;
                Debug.Log("Ultra Mower Added");
            }
            else
            {
                managerControllerScript.displayNotEnoughMoney = true;
            }
        }
    }
}
