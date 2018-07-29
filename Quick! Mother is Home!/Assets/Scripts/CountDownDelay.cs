using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownDelay : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;
    public GameObject countDownDelay;
    // Use this for initialization
    void Start () {

        managerControllerScript = manager.GetComponent<ManagerController>();
        StartCoroutine("StartDelay");
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Countdown from 3 once dayStart has been activated
    IEnumerator StartDelay()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup < pauseTime)
        {
            yield return 0;
        }
        countDownDelay.SetActive(false);
        managerControllerScript.delayCountDownStart = false;
        Time.timeScale = 1;
    }
}
