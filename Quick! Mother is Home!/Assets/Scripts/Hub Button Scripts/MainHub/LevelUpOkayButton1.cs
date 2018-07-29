using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpOkayButton1 : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;
    // Use this for initialization
    void Start () {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

   private void OnMouseDown()
    {
        managerControllerScript.leveledUp = false;
        managerControllerScript.showLevelUpWindow = false;
        managerControllerScript.levelUpTitleObject.SetActive(false);
        managerControllerScript.levelUpTextObject.SetActive(false);
        managerControllerScript.DayOverview();

    }
}
