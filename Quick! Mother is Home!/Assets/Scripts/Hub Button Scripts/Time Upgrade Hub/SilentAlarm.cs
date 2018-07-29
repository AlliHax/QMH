using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilentAlarm : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }
    void OnMouseDown()
    {
        if (managerControllerScript.silentAlarmActivated == false)
        {
            if (managerControllerScript.playerSavings >= 500)
            {

                managerControllerScript.playerSavings = managerControllerScript.playerSavings - 500;
                managerControllerScript.silentAlarmActivated = true;
                Debug.Log("Silent Alaem Added");
            }
            else
            {
                managerControllerScript.displayNotEnoughMoney = true;
            }
        }
    }
}
