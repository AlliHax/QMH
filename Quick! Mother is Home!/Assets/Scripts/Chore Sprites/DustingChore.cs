using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustingChore : MonoBehaviour
{
    public GameObject manager;
    public ManagerController managerControllerScript;

    public GameObject duster;
    public GameObject dusterLimitBox;
    public Transform[] dustSpawnPoints;
    public GameObject[] dustBalls;
    public GameObject[] remainingDustBalls;
    public GameObject randomDustBall;
    public float baseChoreTime = 5.0f;
    public float choreTime;
    public bool timeStopped;
    public int dustBallRemovedCount;

    public GameObject countDownObject;


    private void Start()
    {
        choreTime = baseChoreTime;
        timeStopped = true;
        managerControllerScript = manager.GetComponent<ManagerController>();
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
        dustBallRemovedCount = 0;
        managerControllerScript.backgroundImage.GetComponent<SpriteRenderer>().sprite = managerControllerScript.livingRoomBackground;
        Debug.Log("Dusting Started");
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
        dusterLimitBox.SetActive(true);
        duster.SetActive(true);
        SpawnDustBalls();
    }

    private void SpawnDustBalls()
    {
        foreach (Transform dustBallSpawn in dustSpawnPoints)
        {
            randomDustBall = dustBalls[Random.Range(0, dustBalls.Length)];
            Instantiate(randomDustBall, dustBallSpawn.position, dustBallSpawn.rotation);
        }
    }

    private void CheckForTimeStopped()
    {
        if (choreTime <= 0)
        {
            StopDustingMiniGame();
            managerControllerScript.dustBallOne.SetActive(false);
            managerControllerScript.dustBallTwo.SetActive(false);
            managerControllerScript.dustBallThree.SetActive(false);
            managerControllerScript.dustBallFour.SetActive(false);
            DestroyRemainingDustBalls();
            UpdateManager();
            NextChore();
        }
    }

    private void StopDustingMiniGame()
    {
        timeStopped = true;
        choreTime = baseChoreTime;
        dusterLimitBox.SetActive(false);
        duster.SetActive(false);
    }

    private void DestroyRemainingDustBalls()
    {
        remainingDustBalls = GameObject.FindGameObjectsWithTag("dustBall1");
        for (var i = 0; i < remainingDustBalls.Length; i++)
        {
            Destroy(remainingDustBalls[i]);
        }
        remainingDustBalls = GameObject.FindGameObjectsWithTag("dustBall2");
        for (var i = 0; i < remainingDustBalls.Length; i++)
        {
            Destroy(remainingDustBalls[i]);
        }
        remainingDustBalls = GameObject.FindGameObjectsWithTag("dustBall3");
        for (var i = 0; i < remainingDustBalls.Length; i++)
        {
            Destroy(remainingDustBalls[i]);
        }
        remainingDustBalls = GameObject.FindGameObjectsWithTag("dustBall4");
        for (var i = 0; i < remainingDustBalls.Length; i++)
        {
            Destroy(remainingDustBalls[i]);
        }
    }

    private void UpdateManager()
    {
        managerControllerScript.choreBusy = false;
        managerControllerScript.choresCompleted = managerControllerScript.choresCompleted + 1;
        if (managerControllerScript.swiftyDusterActivated == false)
        {
            managerControllerScript.earnedAllowance = managerControllerScript.earnedAllowance + (dustBallRemovedCount / 8);
        }
        else if (managerControllerScript.swiftyDusterActivated == true)
        {
            managerControllerScript.earnedAllowance = managerControllerScript.earnedAllowance + (dustBallRemovedCount / 6);
        }
        managerControllerScript.rLevelExp = managerControllerScript.rLevelExp + ((dustBallRemovedCount / 4) * .1f);
    }

    private void NextChore()
    {
        if (managerControllerScript.noExtraSlotsUnlocked == true)
        {
            if (managerControllerScript.activateChoreOne == true)
            {
                managerControllerScript.activateChoreOne = false;
                managerControllerScript.activateChoreTwo = true;
            }
            else if (managerControllerScript.activateChoreTwo == true)
            {
                managerControllerScript.activateChoreTwo = false;
            }
        }
        else if (managerControllerScript.choreSlot3UpgradeUnlocked == true)
        {
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
        else if (managerControllerScript.choreSlot4UpgradeUnlocked == true)
        {
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
                managerControllerScript.activateChoreFour = true;
            }
            else if (managerControllerScript.activateChoreFour == true)
            {
                managerControllerScript.activateChoreFour = false;
            }
        }
    }
}
