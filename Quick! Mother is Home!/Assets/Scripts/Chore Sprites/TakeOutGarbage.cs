using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeOutGarbage : MonoBehaviour {

    // Use this for initialization
    public float baseChoreTime = 3f;
    public float choreTime;
    public GameObject manager;
    public ManagerController managerControllerScript;
    private Animator animator;
    public bool disableButton;
    public GameObject trashMiniGameManager;
    public GameObject garbageCollector;
    public TrashMiniGameManager trashMiniGameScript;
    public garbageMiniGame garbageMiniGameScript;
    public bool timeStopped;
    public GameObject[] remainingTrashWads;
    public GameObject countDownObject;

    private void Start()
    {
        animator = GetComponent<Animator>();
        managerControllerScript = manager.GetComponent<ManagerController>();
        trashMiniGameScript = trashMiniGameManager.GetComponent<TrashMiniGameManager>();
        garbageMiniGameScript = garbageCollector.GetComponent<garbageMiniGame>();
        gameObject.SetActive(false);
        choreTime = baseChoreTime;
    }
    void Update()
    {
        CheckForDisable();
        if (timeStopped == false)
        {
            choreTime -= Time.deltaTime;
            CheckForTimeStopped();
        }
        CheckForUpgrades();
    }

    private void OnEnable()
    {
        managerControllerScript.backgroundImage.GetComponent<SpriteRenderer>().sprite = managerControllerScript.kitchenBackground;
        Debug.Log("Trash Chore Started");
        DisableButton();
        countDownObject.SetActive(true);
        StartCoroutine(Countdown());
    }

    public void EndTrashMiniGame()
    {
        CheckForScore();
        managerControllerScript.trashWad.SetActive(false);
        managerControllerScript.bananaPeel.SetActive(false);
        trashMiniGameScript.CancelInvoke("CreateTrashWads");
        trashMiniGameScript.CancelInvoke("CreateBananaPeels");
        garbageCollector.SetActive(false);
        trashMiniGameManager.SetActive(false);
        timeStopped = true;
        DestroyRamainingTrashWads();
        managerControllerScript.choresCompleted = managerControllerScript.choresCompleted + 1;
        managerControllerScript.choreBusy = false;
        garbageMiniGameScript.wadCount = 0;
        choreTime = baseChoreTime;
        NextChore();
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
    private void DestroyRamainingTrashWads()
    {
        remainingTrashWads = GameObject.FindGameObjectsWithTag("TrashWad");
        for (var i = 0; i < remainingTrashWads.Length; i++)
        {
            Destroy(remainingTrashWads[i]);
        }
    }

    private void CheckForTimeStopped()
    {
        if (choreTime <= 0)
        {
            EndTrashMiniGame();
        }
    }

    private void CheckForScore()
    {
        managerControllerScript.earnedAllowance = managerControllerScript.earnedAllowance + garbageMiniGameScript.wadCount;
        managerControllerScript.rLevelExp = managerControllerScript.rLevelExp + (garbageMiniGameScript.wadCount * .2f);
    }

    void DisableButton()
    {
        disableButton = true;
    }
    void CheckForDisable()
    {
        if (disableButton == true)
        {
            animator.SetBool("isActivated", true);
            GetComponent<SpriteRenderer>().color = Color.grey;
        }
        else if (disableButton == false)
        {
            animator.SetBool("isActivated", false);
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void CheckForUpgrades()
    {
        if (managerControllerScript.betterTrashBagsActivated == true)
        {
            trashMiniGameScript.bananaSpawnWaitTime = 1f;
            trashMiniGameScript.trashSpawnWaitTime = .5f;
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
        ActivateMiniGame();
    }

    private void ActivateMiniGame()
    {
        managerControllerScript.choreBusy = true;
        timeStopped = false;
        trashMiniGameManager.SetActive(true);
        garbageCollector.SetActive(true);
    }
}
