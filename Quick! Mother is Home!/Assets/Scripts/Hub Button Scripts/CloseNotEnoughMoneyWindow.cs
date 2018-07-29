using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseNotEnoughMoneyWindow : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    void OnMouseDown()
    {
        managerControllerScript.displayNotEnoughMoney = false;
        managerControllerScript.showDescriptionWindow = true;
        managerControllerScript.notEnoughMoneyWindow.SetActive(false);
        managerControllerScript.notEnoughMoneyTextObject.SetActive(false);
        managerControllerScript.notEnoughMoneyTitleObject.SetActive(false);
    }
}
