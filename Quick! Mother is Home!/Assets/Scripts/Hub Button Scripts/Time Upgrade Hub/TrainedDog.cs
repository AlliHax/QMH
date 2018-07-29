using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainedDog : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }
    void OnMouseDown()
    {
        if (managerControllerScript.trainedDogActivated == false)
        {
            if (managerControllerScript.playerSavings >= 200)
            {

                managerControllerScript.playerSavings = managerControllerScript.playerSavings - 200;
                managerControllerScript.trainedDogActivated = true;
                Debug.Log("Trained Dog");
            }
            else
            {
                managerControllerScript.displayNotEnoughMoney = true;
            }
        }
    }
}
