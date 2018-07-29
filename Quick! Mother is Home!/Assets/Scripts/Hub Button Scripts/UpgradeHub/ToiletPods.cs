using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletPods : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    void OnMouseDown()
    {
        if (managerControllerScript.toiletPodsActivated == false)
        {
            if (managerControllerScript.playerSavings >= 80)
            {
                managerControllerScript.playerSavings = managerControllerScript.playerSavings - 80;
                managerControllerScript.toiletPodsActivated = true;
                Debug.Log("Toilet Pods Added");
            }
            else
            {
                managerControllerScript.displayNotEnoughMoney = true;
            }
        }
    }
}
