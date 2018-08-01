using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepChore : MonoBehaviour {
    public float baseChoreTime = 3f;
    public float choreTime;
    public GameObject manager;
    public ManagerController managerControllerScript;
    private Animator animator;
    public bool disableButton;
    public bool timeStopped;
    public GameObject miniGameBroom;
    public SweepMiniGame sweepMiniGameScript;
    public Collider2D sweepButtonCollider;
    public int sweepMiniGameScore;

    public GameObject dustPan;
    public Sprite dustPanSprite0;
    public Sprite dustPanSprite1;
    public Sprite dustPanSprite2;
    public Sprite dustPanSprite3;

    public GameObject countDownObject;

    private void Start()
    {
        animator = GetComponent<Animator>();
        managerControllerScript = manager.GetComponent<ManagerController>();
        sweepMiniGameScript = miniGameBroom.GetComponent<SweepMiniGame>();
        gameObject.SetActive(false);
        choreTime = baseChoreTime;
        timeStopped = true;
        sweepButtonCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        CheckForDisable();
        if (timeStopped == false)
        {
            choreTime -= Time.deltaTime;
            CheckForTimeStopped();
            Debug.Log(sweepMiniGameScript.sweepSwipe);
        }

        UpdateDustPan();
    }

    private void OnEnable()
    {
        managerControllerScript.backgroundImage.GetComponent<SpriteRenderer>().sprite = managerControllerScript.kitchenBackground;
        Debug.Log("SweepChore Started");
        DisableButton();
        countDownObject.SetActive(true);
        StartCoroutine(Countdown());
    }

    private void CheckForTimeStopped()
    {
        if (choreTime <= 0)
        {
            EndSweepMiniGame();
        }
    }

    private void CheckForScore()
    {
        if(managerControllerScript.biggerBroomActivated == false)
        {
            sweepMiniGameScore = (sweepMiniGameScript.sweepSwipe / 2);
        }
        else if (managerControllerScript.biggerBroomActivated == true)
        {
            sweepMiniGameScore = sweepMiniGameScript.sweepSwipe;
        }
        managerControllerScript.earnedAllowance = managerControllerScript.earnedAllowance + sweepMiniGameScore;
        managerControllerScript.rLevelExp = managerControllerScript.rLevelExp + (sweepMiniGameScore * .2f);
    }
    
    private void UpdateDustPan()
    {
        if (sweepMiniGameScript.sweepSwipe >= 3)
        {
            dustPan.GetComponent<SpriteRenderer>().sprite = dustPanSprite1;
        }
        if (sweepMiniGameScript.sweepSwipe >= 8)
        {
            dustPan.GetComponent<SpriteRenderer>().sprite = dustPanSprite2;
        }
        if (sweepMiniGameScript.sweepSwipe >= 12)
        {
            dustPan.GetComponent<SpriteRenderer>().sprite = dustPanSprite3;
        }
    }
   
    public void EndSweepMiniGame()
    {
        CheckForScore();
        dustPan.GetComponent<SpriteRenderer>().sprite = dustPanSprite0;
        miniGameBroom.SetActive(false);
        dustPan.SetActive(false);
        timeStopped = true;
        managerControllerScript.choresCompleted = managerControllerScript.choresCompleted + 1;
        managerControllerScript.choreBusy = false;
        sweepMiniGameScript.sweepSwipe = 0;
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
        miniGameBroom.SetActive(true);
        dustPan.SetActive(true);
    }

}

