using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageButton : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    private void Update()
    {
        CheckForPopups();
    }

    void OnMouseDown()
    {
        managerControllerScript.viewingGarbageChoreDescription = true;
        managerControllerScript.choreDescriptionTitle.text = "Take out the Garbage";
        managerControllerScript.choreDescriptionText.text = "Collect all the garbage\n in the bin before the\n time runs out!";
        managerControllerScript.choreDescriptionLevelRequirement.text = "RL: 3 Required";
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
