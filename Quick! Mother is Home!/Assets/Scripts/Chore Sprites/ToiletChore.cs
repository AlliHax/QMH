using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletChore : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    public GameObject plunger;
    public GameObject toilet;

    public float baseChoreTime = 5.0f;
    public float choreTime;
    public bool timeStopped;

    public GameObject countDownObject;

    // Use this for initialization
    void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
        timeStopped = true;
        choreTime = baseChoreTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStopped == false)
        {
            choreTime -= Time.deltaTime;
            CheckForTimeStopped();
        }
    }

    private void OnEnable()
    {
        managerControllerScript.backgroundImage.GetComponent<SpriteRenderer>().sprite = managerControllerScript.bathroomBackground;
        Debug.Log("Plunging Started");
        countDownObject.SetActive(true);
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 2f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        countDownObject.gameObject.SetActive(false);
        Time.timeScale = 1;
        timeStopped = false;
        ActivateToiletMiniGame();
    }

    private void ActivateToiletMiniGame()
    {
        plunger.SetActive(true);
        toilet.SetActive(true);
    }

    private void UpdateManager()
    {
        managerControllerScript.choreBusy = false;
        managerControllerScript.choresCompleted = managerControllerScript.choresCompleted + 1;
    }

    private void NextChore()
    {
        Debug.Log("Ending Game");
        if (managerControllerScript.activateChoreOne == true)
        {
            managerControllerScript.activateChoreOne = false;
            managerControllerScript.activateChoreTwo = true;
        }
        else if (managerControllerScript.activateChoreTwo == true)
        {
            managerControllerScript.activateChoreTwo = false;
            managerControllerScript.activateChoreThree = true;
        }
        else if (managerControllerScript.activateChoreThree == true)
        {
            managerControllerScript.activateChoreThree = false;
        }
    }

    private void CheckForTimeStopped()
    {
        if (choreTime <= 0)
        {
            StopToiletMiniGame();
        }
    }

    private void StopToiletMiniGame()
    {
        timeStopped = true;
        managerControllerScript.plunger.SetActive(false);
        managerControllerScript.toilet.SetActive(false);
        UpdateManager();
        choreTime = baseChoreTime;
        NextChore();
    }
}
