using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaundryChore : MonoBehaviour
{
    public GameObject manager;
    public ManagerController managerControllerScript;

    public Transform[] sockSpawnLoactions;
    public GameObject[] socks;
    public GameObject randomSock;
    public GameObject possibleMatchOne;
    public GameObject possibleMatchTwo;
    public GameObject[] remainingSocks;

    public bool sockOneSelected;
    public bool sockTwoSelected;

    public float baseChoreTime = 5.0f;
    public float choreTime;
    public bool timeStopped;

    public GameObject countDownObject;

    private void Start()
    {
        choreTime = baseChoreTime;
        timeStopped = true;
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    private void OnEnable()
    {
        managerControllerScript.backgroundImage.GetComponent<SpriteRenderer>().sprite = managerControllerScript.bathroomBackground;
        sockOneSelected = false;
        sockTwoSelected = false;
        Debug.Log("Laundry Started");
        countDownObject.SetActive(true);
        StartCoroutine(Countdown());
    }

    private void Update()
    {
        if (timeStopped == false)
        {
            choreTime -= Time.deltaTime;
            CheckForTimeStopped();
        }
        if (sockOneSelected == true && sockTwoSelected == true)
        {
            CheckForMatches();
        }
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
        SpawnSocks();
    }

    private void SpawnSocks()
    {
        foreach (Transform sockSpawn in sockSpawnLoactions)
        {
            randomSock = socks[Random.Range(0, socks.Length)];
            Instantiate(randomSock, sockSpawn.position, sockSpawn.rotation);
        }
    }

    private void CheckForMatches()
    {
        if (possibleMatchOne.tag == possibleMatchTwo.tag)
        {
            Debug.Log("MATCH!");
            Destroy(possibleMatchOne);
            Destroy(possibleMatchTwo);
            sockOneSelected = false;
            sockTwoSelected = false;
        }
        else if (possibleMatchOne.tag != possibleMatchTwo.tag)
        {
            Debug.Log("Not a match!");
            sockOneSelected = false;
            sockTwoSelected = false;
        }
    }

    private void CheckForTimeStopped()
    {
        if (choreTime <= 0)
        {
            StopLaundryMiniGame();
            managerControllerScript.whiteSock.SetActive(false);
            managerControllerScript.blueSock.SetActive(false);
            managerControllerScript.purpleSock.SetActive(false);
            DestroyRemainingSocks();
            UpdateManager();
            NextChore();
        }
    }

    private void StopLaundryMiniGame()
    {
        timeStopped = true;
        choreTime = baseChoreTime;
    }

    private void DestroyRemainingSocks()
    {
        remainingSocks = GameObject.FindGameObjectsWithTag("whiteSock");
        for (var i = 0; i < remainingSocks.Length; i++)
        {
            Destroy(remainingSocks[i]);
        }
        remainingSocks = GameObject.FindGameObjectsWithTag("blueSock");
        for (var i = 0; i < remainingSocks.Length; i++)
        {
            Destroy(remainingSocks[i]);
        }
        remainingSocks = GameObject.FindGameObjectsWithTag("purpleSock");
        for (var i = 0; i < remainingSocks.Length; i++)
        {
            Destroy(remainingSocks[i]);
        }
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
}
