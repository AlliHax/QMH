using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SockBehavior : MonoBehaviour {

    public GameObject laundryChoreManager;
    public LaundryChore laundryChoreManagerScript;

    private void OnMouseDown()
    {
        if (laundryChoreManagerScript.sockOneSelected == false)
        {
            laundryChoreManagerScript.possibleMatchOne = this.gameObject;
            laundryChoreManagerScript.sockOneSelected = true;
        }
        else if (laundryChoreManagerScript.sockTwoSelected == false)
        {
            laundryChoreManagerScript.possibleMatchTwo = this.gameObject;
            laundryChoreManagerScript.sockTwoSelected = true;
        }
    }
}
