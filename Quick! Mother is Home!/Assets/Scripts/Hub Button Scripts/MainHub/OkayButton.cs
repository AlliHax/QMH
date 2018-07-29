using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// DAY OVERVIEW OKAY BUTTON
public class OkayButton : MonoBehaviour {
    public GameObject manager;
    public GameObject dishChore;
    public GameObject sweepChore;
    public GameObject trashChore;

    public SavingManager savingManagerScript;
    public GameObject savingController;

    public ManagerController managerControllerScript;
    public DishChore dishChoreScript;
    public SweepChore sweepChoreScript;
    public TakeOutGarbage trashChoreScript;

    public Transform cameraLocation;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
        savingManagerScript = savingController.GetComponent<SavingManager>();
        dishChoreScript = dishChoreScript.GetComponent<DishChore>();
        sweepChoreScript = sweepChoreScript.GetComponent<SweepChore>();
        trashChoreScript = trashChoreScript.GetComponent<TakeOutGarbage>();

    }
    void OnMouseDown () {
        managerControllerScript.showOverview = false;
        ResetAllButtons();
        managerControllerScript.showPlayerStats = true;
        Camera.main.transform.position = cameraLocation.position;
        managerControllerScript.showMainHud = true;
        managerControllerScript.earnedAllowance = 0;
        managerControllerScript.choresCompleted = 0;
        savingManagerScript.Save();
    }
    //Prepares all buttons for next day.
    void ResetAllButtons() 
    {
        dishChoreScript.disableButton = false;
        sweepChoreScript.disableButton = false;
        trashChoreScript.disableButton = false;
    }
}
