using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// DAY OVERVIEW OKAY BUTTON
// Also used for grounded okay button
public class OkayButton : MonoBehaviour {
    public GameObject manager;

    public SavingManager savingManagerScript;
    public GameObject savingController;

    public ManagerController managerControllerScript;
    public DishChore dishChoreScript;
    public SweepChore sweepChoreScript;
    public TakeOutGarbage trashChoreScript;

    public Transform cameraLocation;

    public AudioClip buttonPushedSound;
    public AudioSource soundEffectSource;
    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
        savingManagerScript = savingController.GetComponent<SavingManager>();
        dishChoreScript = dishChoreScript.GetComponent<DishChore>();
        sweepChoreScript = sweepChoreScript.GetComponent<SweepChore>();
        trashChoreScript = trashChoreScript.GetComponent<TakeOutGarbage>();

    }
    void OnMouseDown () {
        soundEffectSource.clip = buttonPushedSound;
        soundEffectSource.Play();
        managerControllerScript.showOverview = false;
        managerControllerScript.groundedWindow.SetActive(false);
        managerControllerScript.groundedTitleText.SetActive(false);
        managerControllerScript.groundedDescriptionText.SetActive(false);
        managerControllerScript.grounded = false;
        managerControllerScript.showPlayerStats = true;
        Camera.main.transform.position = cameraLocation.position;
        managerControllerScript.showMainHud = true;
        managerControllerScript.earnedAllowance = 0;
        managerControllerScript.choresCompleted = 0;
        savingManagerScript.Save();
    }
}
