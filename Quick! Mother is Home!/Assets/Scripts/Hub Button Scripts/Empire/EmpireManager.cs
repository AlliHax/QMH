using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpireManager : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;
    public int lemonadeFlavorUpgradeCount;

    // Use this for initialization
    void Start () {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    private void CalculateLemonadeRevenue()
    {

    }


}
