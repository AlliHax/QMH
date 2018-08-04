using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepButton : MonoBehaviour
{
    public GameObject manager;
    public ManagerController managerControllerScript;
    public AudioClip buttonPushedSound;
    public AudioSource soundEffectSource;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
        soundEffectSource.clip = buttonPushedSound;
    }

    private void Update()
    {
        CheckForPopups();
       
    }

    void OnMouseDown()
    {
        soundEffectSource.Play();
        managerControllerScript.viewingSweepingChoreDescription = true;
        managerControllerScript.choreDescriptionTitle.text = "Sweeping";
        managerControllerScript.choreDescriptionText.text = "Sweep the floor as fast\n as you can before\n the time runs out!";
        managerControllerScript.choreDescriptionLevelRequirement.text = "RL: 2 Required";
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
