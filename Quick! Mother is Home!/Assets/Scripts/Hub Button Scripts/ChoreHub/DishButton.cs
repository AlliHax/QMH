using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishButton : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;
    // Use this for initialization
    void Start () {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }
	
	void Update ()
    {
        CheckForPopups();
	}

    private void OnMouseDown()
    {
        managerControllerScript.viewingDishChoreDescription = true;
        managerControllerScript.choreDescriptionTitle.text = "Dishes";
        managerControllerScript.choreDescriptionText.text = "Click on as many dirty plates\n as you can before the\n time runs out!";
        managerControllerScript.choreDescriptionLevelRequirement.text = "RL: 1 Required";
        managerControllerScript.popupWindowOpen = true;

        managerControllerScript.viewChoreDescriptionWindow = true;
    }

    private void CheckForPopups()
    {
        if (managerControllerScript.popupWindowOpen == true)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
        else if (managerControllerScript.popupWindowOpen == false)
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }
}
