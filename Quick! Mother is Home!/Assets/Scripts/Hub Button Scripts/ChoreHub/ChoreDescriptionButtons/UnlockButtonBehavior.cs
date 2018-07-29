using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockButtonBehavior : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;
    // Use this for initialization
    void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    // Update is called once per frame
    void Update () {
        if (managerControllerScript.viewingDishChoreDescription == true)
        {
            GetComponent<SpriteRenderer>().color = Color.grey;
        }
        else if (managerControllerScript.viewingSweepingChoreDescription == true)
        {
            if (managerControllerScript.broomUnlocked == true)
            {
                GetComponent<SpriteRenderer>().color = Color.grey;
            }
            else if (managerControllerScript.broomUnlocked == false)
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        else if (managerControllerScript.viewingGarbageChoreDescription == true)
        {
            if (managerControllerScript.garbageUnlocked == true)
            {
                GetComponent<SpriteRenderer>().color = Color.grey;
            }
            else if (managerControllerScript.garbageUnlocked == false)
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        else if (managerControllerScript.viewingDustingChoreDescription == true)
        {
            if (managerControllerScript.dusterUnlocked == true)
            {
                GetComponent<SpriteRenderer>().color = Color.grey;
            }
            else if (managerControllerScript.dusterUnlocked == false)
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

    private void OnMouseDown()
    {
        if (managerControllerScript.viewingDishChoreDescription == true)
        {
            GetComponent<SpriteRenderer>().color = Color.grey;
            Debug.Log("You Already have this unlocked!");

        }
        else if (managerControllerScript.viewingSweepingChoreDescription == true)
        {
            if (managerControllerScript.responsibilityLevel >= 2)
            {
                managerControllerScript.totalChores = managerControllerScript.totalChores + 1;
                managerControllerScript.broomUnlocked = true;
            }
            else
            {
                managerControllerScript.displayNotResponsible = true;
                managerControllerScript.viewChoreDescriptionWindow = false;
            }
        }
        else if (managerControllerScript.viewingGarbageChoreDescription == true)
        {
            if (managerControllerScript.garbageUnlocked == false)
            {
                if (managerControllerScript.responsibilityLevel >= 3)
                {
                    managerControllerScript.totalChores = managerControllerScript.totalChores + 1;
                    managerControllerScript.garbageUnlocked = true;
                    GetComponent<SpriteRenderer>().color = Color.grey;
                }
                else
                {
                    managerControllerScript.displayNotResponsible = true;
                    managerControllerScript.viewChoreDescriptionWindow = false;
                }
            }
        }
        else if (managerControllerScript.viewingDustingChoreDescription == true)
        {
            if (managerControllerScript.dusterUnlocked == false)
            {
                if (managerControllerScript.responsibilityLevel >= 4)
                {
                    managerControllerScript.totalChores = managerControllerScript.totalChores + 1;
                    managerControllerScript.dusterUnlocked = true;
                    GetComponent<SpriteRenderer>().color = Color.grey;
                }
                else
                {
                    managerControllerScript.displayNotResponsible = true;
                    managerControllerScript.viewChoreDescriptionWindow = false;
                }
            }
        }
    }
}
