using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishChore : MonoBehaviour
{
    public GameObject manager;
    public ManagerController managerControllerScript;
    public GameObject dirtyDish;
    public dirtyDishBehavior dirtyDishScript;
    public float baseChoreTime = 5.0f;
    public float choreTime;
    public bool timeStopped;
    public GameObject miniGameManager;
    public DishMiniGame dishGameScript;
    private Animator animator;
    public bool disableButton;
    public GameObject[] leftoverDishes;
    public GameObject countDownObject;

    public bool participatedInChore;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
        managerControllerScript = manager.GetComponent<ManagerController>();
        dishGameScript = miniGameManager.GetComponent<DishMiniGame>();
        timeStopped = true;
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

    private void DestroyRemainingDishes()
    {
        leftoverDishes = GameObject.FindGameObjectsWithTag("dish");
        for (var i = 0; i < leftoverDishes.Length; i++)
        {
            Destroy(leftoverDishes[i]);
        }
    }

    private void OnEnable()
    {
        managerControllerScript.backgroundImage.GetComponent<SpriteRenderer>().sprite = managerControllerScript.kitchenBackground;
        Debug.Log("Dish Chore Started");
        participatedInChore = false;
        DisableButton();
        countDownObject.SetActive(true);
        StartCoroutine(Countdown());
    }

    private void CheckForTimeStopped()
    {
        if (choreTime <= 0)
        {
            StopDishMiniGame();
        }
    }
    private void StopDishMiniGame()
    {
        managerControllerScript.diryDish.SetActive(false);
        dishGameScript.CancelInvoke("CreateDishes");
        DestroyRemainingDishes();
        UpdateManager();
        miniGameManager.SetActive(false);
        timeStopped = true;
        choreTime = baseChoreTime;
        NextChore();
    }
    private void NextChore()
    {
        Debug.Log("Ending Game");
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

    private void UpdateManager()
    {
        managerControllerScript.choreBusy = false;
        managerControllerScript.choresCompleted = managerControllerScript.choresCompleted + 1;
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
        if (managerControllerScript.spongeActivated == true)
        {
            dishGameScript.spawnDishWaitTime = .5f;
            dirtyDishScript.dishCount = 2;

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
        miniGameManager.SetActive(true);
    }
}
