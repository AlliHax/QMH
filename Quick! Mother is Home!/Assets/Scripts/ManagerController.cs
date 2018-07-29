using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ManagerController : MonoBehaviour {
    public GameObject savingManager;
    public SavingManager savingManagerScript;
    public bool notFirstTimeRun;
    //Variables for Player
    public GameObject player;
    // Variables for Assigning Chores
    public List<GameObject> chores = new List<GameObject>();
    public GameObject choreNumberOne;
    public GameObject choreNumberTwo;
    public GameObject choreNumberThree;
    public GameObject choreNumberFour;
    public bool choresNeedAssignment;
    public bool activateChoreOne;
    public bool activateChoreTwo;
    public bool activateChoreThree;
    public bool activateChoreFour;
    public bool beginChoreOrder;
    public bool noExtraSlotsUnlocked;
    public bool choreSlot3UpgradeUnlocked;
    public bool choreSlot4UpgradeUnlocked;
    public bool unlockDustingChore;
    public bool unlockGarbageChore;
    //Variables for Background Image
    public GameObject backgroundImage;
    public Sprite kitchenBackground;
    public Sprite livingRoomBackground;
    public Sprite bathroomBackground;
    public Sprite backyardBackground;
    // Variables for Delay Count Down
    public GameObject startDelayCountDown;
    public bool delayCountDownStart;
    //Display Chore List
    public bool showStickyNote;
    public GameObject stickyNote;
    public GameObject choreStickyNoteTitleObject;
    public GameObject notepadChoreNumberOneObject;
    public GameObject notepadChoreNumberTwoObject;
    public GameObject notepadChoreNumberThreeObject;
    public Text notepadChoreNumberOneText;
    public Text notepadChoreNumberTwoText;
    public Text notepadChoreNumberThreeText;
    //Variables for Displaying Total Savings
    public Text totalSavingsText;
    public GameObject totalSavingsTextObject;
    public bool showPlayerStats;
    //Responsablity Level Variables
    public int responsibilityLevel;
    public float rLevelExp;
    public float expNeeded;
    public bool expEarned;
    public Text responsiblityLevelText;
    public GameObject responsiblityLevelTextObject;
    //Variables for Calculating Savings and Chores Completed
    public int playerSavings;
    public int earnedAllowance;
    public int daysTotal;
    public int totalChores;
    public int choresCompleted;
    //Start of Day
    public bool dayStart = false;
    public Transform cameraLocation;
    //Variables for Main HUD Menu
    public GameObject mainHud;
    public bool showMainHud;
    public Text notEnoughMoneyTitleText;
    public Text notEnoughMoneyText;
    public GameObject notEnoughMoneyTitleObject;
    public GameObject notEnoughMoneyTextObject;
    //Variabled for DayOverview()
    public GameObject dayOverview;
    public bool showOverview;
    public Text moneyEarnedText;
    public Text passiveMoneyEarned;
    public GameObject overviewTextObject;
    public Text overViewTitleText;
    public GameObject passiveMoneyEarnedObject;
    public GameObject overViewTitleGameObject;
    public string moneyEarned;
    public string passiveMoneyEarnedText;
    public string motherHomeTitle;
    public string choresDoneTitle;
    //Variables for Level Up
    public bool showLevelUpWindow;
    public bool leveledUp;
    public GameObject levelUpWindow;
    public GameObject levelUpTitleObject;
    public GameObject levelUpTextObject;
    public Text levelUpTitleText;
    public Text levelUpText;
    public string levelUpTitleTextString;
    public string levelUpTextString;
    public int addedTime = 1;
    public int bonusAllowance = 4;
    public bool gotBonusAllowance;
    // button variables
    public GameObject dishChoreButton;
    public GameObject sweepChoreButton;
    public SweepChore sweepChoreScript;
    public GameObject garbageChoreButton;

    //minigame variables
    public bool dishMiniGameReady;
    public GameObject diryDish;
    public GameObject trashWad;
    public GameObject bananaPeel;
    public GameObject whiteSock;
    public GameObject blueSock;
    public GameObject purpleSock;
    public GameObject dustBallOne;
    public GameObject dustBallTwo;
    public GameObject dustBallThree;
    public GameObject dustBallFour;
    public GameObject plug;
    public GameObject outlet;
    public GameObject plunger;
    public GameObject toilet;
    public GameObject mower;
    public GameObject unCutGrass;
    public GameObject cutGrass;
    public GameObject rock;
    public GameObject poo;
    public GameObject bag;
    //Variables for Upgrade Huds
    public GameObject choreHud;
    public GameObject upgradeHud;
    public GameObject empireHud;
    public GameObject lemonadeHud;
    public GameObject notResponsibleWindow;
    public GameObject notEnoughMoneyWindow;
    public bool showDescriptionWindow;
    public GameObject descriptionWindow;
    public GameObject descriptionTextObject;
    public GameObject descriptionTitleObject;
    public GameObject descriptionPriceTextObject;
    public bool viewingSpongeUpgradeDescription;
    public bool viewingBroomUpgradeDescription;
    public bool viewingGarbageUpgradeDescription;
    public bool viewingDusterUpgradeDescription;
    public bool viewingChoreSlot3UpgradeDescription;
    public GameObject funnyDescriptionTextObject;
    public GameObject notResponsibleEnoughTitleObject;
    public GameObject notResponsibleEnoughTextObject;
    public Text notResponsibleEnoughTitle;
    public Text notResponsibleEnoughText;
    public Text descriptionText;
    public Text descriptionTitle;
    public Text descriptionPriceText;
    public Text funnyDescriptionText;
    public bool showChoreUpgradeHud;
    public bool showToolUpgradeHud;
    public bool showEmpireHud;
    public bool showLemonadeHud;
    public bool displayNotResponsible;
    public bool displayNotEnoughMoney;
    // Variables for Empire
    public int empireRevenue;
    public Text lemonadeTotalPerDayText;
    public GameObject lemonadeTotalPerDayObject;
    public GameObject lemonadeTotalPerDayObjectForHud;
    public Text lemonadeTotalPerDayForHudText;
    public GameObject empireUpgradeDescriptionWindow;
    public bool showEmpireUpgradeDescriptionWindow;
    public bool lemonadePurchased;
    public GameObject lemonadeUpgradeBodys;
    public GameObject lemonadePurchaseButton;
    public int lemonadeRevenue;
    public GameObject empireDescriptionTitleObject;
    public GameObject empireDescriptionBodyObject;
    public Text empireDescriptionTitleText;
    public Text empireDescriptionBodyText;
    public GameObject lemonadeEmpireTitleText;
    public GameObject lemonadeEmpireDescriptionText;
    //Variables for Empire Upgrades
    public bool hideEmpireUpgradeCounts;
    public int flavorLemonadeUpgradeCount;
    public int flavorUpgradePrice;
    public GameObject lemonadeUpgradeCountTextObject;
    public Text flavorLemonadeUpgradeCountText;
    public GameObject flavorUpgradeCostObject;
    public Text flavorUpgradeCostText;
    //Gameobjects for Chores
    public GameObject dustingChoreObject;
    public GameObject garbageChoreObject;
    
    //Variables for Tool and Time Upgrades
    public bool spongeActivated;
    public bool biggerBroomActivated;
    public bool betterTrashBagsActivated;
    public bool toiletPodsActivated;
    public bool swiftyDusterActivated;
    public bool aquaBaseActivated;
    public bool betterDetergentActivated;
    public bool betterVacuumActivated;
    public bool weedKillerActivated;
    public bool pooperScooperActivated;
    public bool ultraMowerActivated;
    public bool dustingChoreUnlocked;
    //Time Upgrade Variables
    public bool extraLockActivated;
    public bool walkieTalkieActivated;
    public bool cellphoneActivated;
    public bool silentAlarmActivated;
    public bool trainedDogActivated;
    //Chore Upgrades
    public bool spongeUnlocked;
    public bool broomUnlocked;
    public bool garbageUnlocked;
    public bool dusterUnlocked;
    public bool toiletUpgrade;
    public bool washerUpgrade;
    public bool vacuumUpgrade;
    public bool wasteUpgrade;
    public bool plantUpgrade;
    public bool mowerUpgrade;
    public bool backyardWeedsUpgrade;
    public bool viewChoreDescriptionWindow;
    public GameObject choreDescriptionWindow;
    public GameObject choreDescriptionTitleObject;
    public GameObject choreDescriptionTextObject;
    public GameObject choreDescriptionLevelRequirementObject;
    public Text choreDescriptionTitle;
    public Text choreDescriptionText;
    public Text choreDescriptionLevelRequirement;
    public bool viewingDishChoreDescription;
    public bool viewingSweepingChoreDescription;
    public bool viewingGarbageChoreDescription;
    public bool viewingDustingChoreDescription;
    //Time Upgrades
    public bool extraLockUpgrade;
    public bool walkieTalkieUpgrade;
    public bool cellphoneUpgrade;
    public bool silentAlarmUpgrade;
    public bool trainedDogUpgrade;
    public bool viewingExtraLockUpgradeDescription;

    //Chore activate?
    public bool choreBusy;

    //Disable other buttons while pop up windows are opened
    public bool popupWindowOpen;

    public bool disableChoresOnStart;
    public void Awake()
    {
        savingManagerScript = savingManager.GetComponent<SavingManager>();
        savingManagerScript.Load();
        if(dustingChoreUnlocked == true)
        {
            chores.Add(dustingChoreObject);
            Debug.Log("Dusting Chore Already Added");
        }
    }

    void Start()
    {
         if (notFirstTimeRun == false)
        {
            noExtraSlotsUnlocked = true;
        }
        showPlayerStats = true;
        //playerSavings = 0;
        earnedAllowance = 0;
        choresCompleted = 0;
        showMainHud = true;
        //responsibilityLevel = 1;
        expNeeded = 2;
        rLevelExp = 0;
        choreBusy = false;     
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateRL();
        CalculateEmpireRevenue();
        HudController();
        totalSavingsText.text = "$ " + playerSavings;
        responsiblityLevelText.text = "RL:" + responsibilityLevel;
        lemonadeTotalPerDayText.text = "$ " + lemonadeRevenue.ToString();
        if (dayStart == true)
        {
            if (choresNeedAssignment == true)
            {
                AssignChores();
            }
            CheckChoreActivation();
            mainHud.SetActive(false);
            disableChoresOnStart = true;
            startDelayCountDown.SetActive(true);
            StartCoroutine("MomHomeMessage");
            EndOfDay();
        }
        CheckForTimeUpgrades();
        PlayerVisable();
        if (delayCountDownStart == false)
        {
            startDelayCountDown.SetActive(false);
            disableChoresOnStart = false;
        }
        ShowPlayerStats();
        UpdateChoreList();
    }

    //Activiates/Deactivates all hubs and overviews.
    void HudController()
    {
        if (showMainHud == true)
        {
            mainHud.SetActive(true);
        }
        else if (showMainHud == false)
        {
            mainHud.SetActive(false);
        }
        if (showChoreUpgradeHud == true)
        {
            showMainHud = false;
            mainHud.SetActive(false);
            choreHud.SetActive(true);
        }
        else if (showChoreUpgradeHud == false)
        {
            choreHud.SetActive(false);
        }
        if (showToolUpgradeHud == true)
        {
            showMainHud = false;
            mainHud.SetActive(false);
            upgradeHud.SetActive(true);
        }
        else if (showToolUpgradeHud == false)
        {
            upgradeHud.SetActive(false);
        }
        if (showEmpireHud == true)
        {
            showMainHud = false;
            mainHud.SetActive(false);
            empireHud.SetActive(true);
            lemonadeTotalPerDayObject.SetActive(true);
        }
        else if (showEmpireHud == false)
        {
            empireHud.SetActive(false);
            lemonadeTotalPerDayObject.SetActive(false);
        }
        if (showLemonadeHud == true)
        {
            lemonadeHud.SetActive(true);
            empireHud.SetActive(false);
            lemonadeTotalPerDayObject.SetActive(false);
            lemonadeTotalPerDayObjectForHud.SetActive(true);
            lemonadeTotalPerDayForHudText.text = "Revenue $ " + lemonadeRevenue.ToString();
            flavorUpgradeCostText.text = "$" + flavorUpgradePrice.ToString();
            if (lemonadePurchased == true)
            {
                flavorLemonadeUpgradeCountText.text = flavorLemonadeUpgradeCount.ToString();
                lemonadeUpgradeBodys.SetActive(true);
                lemonadePurchaseButton.SetActive(false);
                lemonadeEmpireTitleText.SetActive(false);
                lemonadeEmpireDescriptionText.SetActive(false);

                if (hideEmpireUpgradeCounts == true)
                {
                    lemonadeTotalPerDayObjectForHud.SetActive(false);
                    lemonadeUpgradeCountTextObject.SetActive(false);
                }
                else if (hideEmpireUpgradeCounts == false)
                {
                    lemonadeUpgradeCountTextObject.SetActive(true);
                    lemonadeTotalPerDayObjectForHud.SetActive(true);
                }
            }
            else if (lemonadePurchased == false)
            {
                lemonadePurchaseButton.SetActive(true);
                lemonadeEmpireTitleText.SetActive(true);
                lemonadeEmpireDescriptionText.SetActive(true);
            }
        }
        else if (showLemonadeHud == false)
        {
            lemonadeHud.SetActive(false);
            lemonadeUpgradeCountTextObject.SetActive(false);
            lemonadeTotalPerDayObjectForHud.SetActive(false);
            lemonadeEmpireTitleText.SetActive(false);
            lemonadeEmpireDescriptionText.SetActive(false);
        }
        
        if (showEmpireUpgradeDescriptionWindow == true)
        {
            empireUpgradeDescriptionWindow.SetActive(true);
            empireDescriptionTitleObject.SetActive(true);
            empireDescriptionBodyObject.SetActive(true);
        }
        else if (showEmpireUpgradeDescriptionWindow == false)
        {
            empireUpgradeDescriptionWindow.SetActive(false);
            empireDescriptionTitleObject.SetActive(false);
            empireDescriptionBodyObject.SetActive(false);
        }
        if (showOverview == true)
        {
            showMainHud = false;
            dayOverview.SetActive(true);
            overviewTextObject.SetActive(true);
            passiveMoneyEarnedObject.SetActive(true);
            overViewTitleGameObject.SetActive(true);
        }
        else if (showOverview == false)
        {
            showMainHud = true;
            dayOverview.SetActive(false);
            overviewTextObject.SetActive(false);
            passiveMoneyEarnedObject.SetActive(false);
            overViewTitleGameObject.SetActive(false);
        }
        if (displayNotEnoughMoney == true)
        {
            notEnoughMoneyTitleText.text = "Need More $$";
            notEnoughMoneyText.text = "You can't afford this upgrade.\n :(";
            notEnoughMoneyTextObject.SetActive(true);
            notEnoughMoneyTitleObject.SetActive(true);
            notEnoughMoneyWindow.SetActive(true);
        }
        else if(displayNotEnoughMoney == false)
        {
            notEnoughMoneyWindow.SetActive(false);
            notEnoughMoneyTextObject.SetActive(false);
            notEnoughMoneyTitleObject.SetActive(false);
        }
        if (displayNotResponsible == true)
        {
            notResponsibleWindow.SetActive(true);
            notResponsibleEnoughTitle.text = "Uh Oh!";
            notResponsibleEnoughText.text = "Your are not responsible\n enough to take on this chore.";
            notResponsibleEnoughTextObject.SetActive(true);
            notResponsibleEnoughTitleObject.SetActive(true);
        }
        else if (displayNotResponsible == false)
        {
            notResponsibleWindow.SetActive(false);
            notResponsibleEnoughTextObject.SetActive(false);
            notResponsibleEnoughTitleObject.SetActive(false);
        }
        if (showLevelUpWindow == true)
        {
            levelUpWindow.SetActive(true);
            levelUpTitleObject.SetActive(true);
            levelUpTextObject.SetActive(true);
        }
        else if (showLevelUpWindow == false)
        {
            levelUpWindow.SetActive(false);
            levelUpTitleObject.SetActive(false);
            levelUpTextObject.SetActive(false);
        }
        if (showDescriptionWindow == true)
        {
            descriptionWindow.SetActive(true);
            descriptionTitleObject.SetActive(true);
            descriptionTextObject.SetActive(true);
            descriptionPriceTextObject.SetActive(true);
        }
        else if (showDescriptionWindow == false)
        {
            descriptionWindow.SetActive(false);
            descriptionTitleObject.SetActive(false);
            descriptionTextObject.SetActive(false);
            descriptionPriceTextObject.SetActive(false);
        }
        if (viewChoreDescriptionWindow == true)
        {
            choreDescriptionWindow.SetActive(true);
            choreDescriptionTitleObject.SetActive(true);
            choreDescriptionTextObject.SetActive(true);
            choreDescriptionLevelRequirementObject.SetActive(true);
        }
        else if (viewChoreDescriptionWindow == false)
        {
            choreDescriptionWindow.SetActive(false);
            choreDescriptionTitleObject.SetActive(false);
            choreDescriptionTextObject.SetActive(false);
            choreDescriptionLevelRequirementObject.SetActive(false);
        }
        if (showStickyNote == true)
        {
            stickyNote.SetActive(true);
            choreStickyNoteTitleObject.SetActive(true);
            notepadChoreNumberOneObject.SetActive(true);
            notepadChoreNumberTwoObject.SetActive(true);
            if(choreSlot3UpgradeUnlocked == true)
            {
                notepadChoreNumberThreeObject.SetActive(true);
            }
        }
        else if (showStickyNote == false)
        {
            stickyNote.SetActive(false);
            choreStickyNoteTitleObject.SetActive(false);
            notepadChoreNumberOneObject.SetActive(false);
            notepadChoreNumberTwoObject.SetActive(false);
            notepadChoreNumberThreeObject.SetActive(false);
        }
    }

    private void AssignChores()
    {
        notFirstTimeRun = true;
        if (noExtraSlotsUnlocked == true)
        {
            choreNumberOne = chores[Random.Range(0, chores.Count)];
            choreNumberTwo = chores[Random.Range(0, chores.Count)];
            totalChores = 2;
            while (choreNumberTwo == choreNumberOne)
            {
                choreNumberTwo = chores[Random.Range(0, chores.Count)];
            }
            choresNeedAssignment = false;
        }
        else if (choreSlot3UpgradeUnlocked == true)
        {
            choreNumberOne = chores[Random.Range(0, chores.Count)];
            choreNumberTwo = chores[Random.Range(0, chores.Count)];
            totalChores = 3;
            while (choreNumberTwo == choreNumberOne)
            {
                choreNumberTwo = chores[Random.Range(0, chores.Count)];
            }
            choreNumberThree = chores[Random.Range(0, chores.Count)];
            while (choreNumberThree == choreNumberOne || choreNumberThree == choreNumberTwo)
            {
                choreNumberThree = chores[Random.Range(0, chores.Count)];
            }
            choresNeedAssignment = false;
        }
        else if (choreSlot4UpgradeUnlocked == true)
        {
            choreNumberOne = chores[Random.Range(0, chores.Count)];
            choreNumberTwo = chores[Random.Range(0, chores.Count)];
            totalChores = 4;
            while (choreNumberTwo == choreNumberOne)
            {
                choreNumberTwo = chores[Random.Range(0, chores.Count)];
            }
            choreNumberThree = chores[Random.Range(0, chores.Count)];
            while (choreNumberThree == choreNumberOne || choreNumberThree == choreNumberTwo)
            {
                choreNumberThree = chores[Random.Range(0, chores.Count)];
            }
            choreNumberFour = chores[Random.Range(0, chores.Count)];
            while (choreNumberFour == choreNumberOne || choreNumberFour == choreNumberTwo || choreNumberFour == choreNumberThree)
            {
                choreNumberFour = chores[Random.Range(0, chores.Count)];
            }
            choresNeedAssignment = false;
        }
    }

    private void CheckChoreActivation()
    {
        if (activateChoreOne == true)
        {
            choreNumberOne.SetActive(true);
        }
        else if (activateChoreOne == false)
        {
            choreNumberOne.SetActive(false);
        }
        if (activateChoreTwo == true)
        {
            choreNumberOne.SetActive(false);
            choreNumberTwo.SetActive(true);
        }
        else if (activateChoreTwo == false)
        {
            choreNumberTwo.SetActive(false);
        }
        if (choreSlot3UpgradeUnlocked == true)
        {
            if (activateChoreThree == true)
            {
                choreNumberTwo.SetActive(false);
                choreNumberThree.SetActive(true);
            }
            else if (activateChoreThree == false)
            {
                choreNumberThree.SetActive(false);
            }
        }
        if (choreSlot4UpgradeUnlocked == true)
        {
            if (activateChoreThree == true)
            {
                choreNumberTwo.SetActive(false);
                choreNumberThree.SetActive(true);
            }
            else if (activateChoreThree == false)
            {
                choreNumberThree.SetActive(false);
            }
            if (activateChoreFour == true)
            {
                choreNumberThree.SetActive(false);
                choreNumberFour.SetActive(true);
            }
            else if (activateChoreThree == false)
            {
                choreNumberFour.SetActive(false);
            }
        }
    }

    private void StartChoreOrder()
    {
        if(beginChoreOrder == true)
        {
            activateChoreOne = true;
            beginChoreOrder = false;
        }
    }

    // Determines whether the player's money and RL level should be displayed
    private void ShowPlayerStats()
    {
        if(showPlayerStats == true)
        {
            totalSavingsTextObject.SetActive(true);
            responsiblityLevelTextObject.SetActive(true);
        }
        else if (showPlayerStats == false)
        {
            totalSavingsTextObject.SetActive(false);
            responsiblityLevelTextObject.SetActive(false);
        }
    }

    //Calculates the player's allowance based on total chores completed/ total chores activated.
    void CalculateEmpireRevenue()
    {
        //lemonadeRevenue = lemonadeRevenue + (flavorLemonadeUpgradeCount * 3);
        empireRevenue = lemonadeRevenue; //eventually add the other two in.
    }

    //Calculates Player's savings.
    void CalculateSavings()
    {
        playerSavings = playerSavings + earnedAllowance + empireRevenue;
    }

    void CalculateTotalEarnedForDay()
    {
        daysTotal = earnedAllowance + empireRevenue;
    }

    //Calculates the players Responsibility level.
    void CalculateRL()
    {
        if (rLevelExp >= expNeeded)
        {
            responsibilityLevel = responsibilityLevel + 1;
            expNeeded = expNeeded * 2;
            leveledUp = true;
        }
    }

    private void UpdateChoreList()
    {
        if (unlockDustingChore == true)
        {
            dustingChoreUnlocked = true;
            chores.Add(dustingChoreObject);
            unlockDustingChore = false;
        }
        if(unlockGarbageChore == true)
        {
            chores.Add(garbageChoreObject);
            unlockGarbageChore = false;
        }
    }

    IEnumerator MomHomeMessage()
    {
        notepadChoreNumberOneText.text = choreNumberOne.name.ToString();
        notepadChoreNumberTwoText.text = choreNumberTwo.name.ToString();
        notepadChoreNumberThreeText.text = choreNumberThree.name.ToString();
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3f;
        
        while (Time.realtimeSinceStartup < pauseTime)
        {
            yield return 0;
        }
        showStickyNote = false;
        delayCountDownStart = false;
        StartChoreOrder();
        startDelayCountDown.SetActive(false);
        Time.timeScale = 1;
        
    }
    //If day has started timer begins to count down and checks for players progress on completing the chores.
    void EndOfDay()
    {
        if (choresCompleted == totalChores)
        {
            choresDoneTitle = ("All Chores Finished!");
            overViewTitleText.text = choresDoneTitle;
            dayStart = false;
            Camera.main.transform.position = cameraLocation.position;
            CalculateRL();
            DayOverview();
        }
    }

    // Check to see if any upgrades are available and addes it to timeleft.
    void CheckForTimeUpgrades()
    {
        if (extraLockUpgrade == false)
        {
            if (extraLockActivated == true)
            {
                extraLockUpgrade = true;
            }
        }
        if (trainedDogUpgrade == false)
        {
            if (trainedDogActivated == true)
            {
                trainedDogUpgrade = true;
            }
        }
        if (walkieTalkieUpgrade == false)
        {
            if (walkieTalkieActivated == true)
            {
                walkieTalkieUpgrade = true;
            }
        }
        if (cellphoneUpgrade == false)
        {
            if (cellphoneActivated == true)
            {
                cellphoneUpgrade = true;
            }
        }
        if (silentAlarmUpgrade == false)
        {
            if (silentAlarmActivated == true)
            {
                silentAlarmUpgrade = true;
            }
        }
    }

    //Calculates the players savings, earned allowance, and responsibility level and displays end of day screen.
    public void DayOverview()
    {
        CalculateSavings();
        CalculateTotalEarnedForDay();
        if (leveledUp == true)
        {
            levelUpTitleObject.SetActive(true);
            levelUpTextObject.SetActive(true);
            levelUpTitleText.text = "Leveled Up!";
            levelUpText.text = "You're more Responsible now!\n Responseability Level: " + responsibilityLevel + "!";
            showLevelUpWindow = true;
            moneyEarned = ("You earned $" + earnedAllowance.ToString() + " Today from Chores!");
            moneyEarnedText.text = moneyEarned;
            passiveMoneyEarnedText = ("You earned $" + empireRevenue.ToString() + " from your Empire!");
            passiveMoneyEarned.text = passiveMoneyEarnedText;
            if (responsibilityLevel == 3)
            {
                unlockDustingChore = true;
            }
            if (responsibilityLevel == 4)
            {
                unlockGarbageChore = true;
            }
        }
        else
        {
            moneyEarned = ("You earned $" + earnedAllowance.ToString() + " Today!");
            moneyEarnedText.text = moneyEarned;
            passiveMoneyEarnedText = ("You earned $" + empireRevenue.ToString() + " from your Empire!");
            passiveMoneyEarned.text = passiveMoneyEarnedText;
            showOverview = true;
        }
    }


    //Player Sprite is not visible in Center of room while other Animations are playing.
    void PlayerVisable()
    {
        if (choreBusy == false)
        {
            sweepChoreButton.GetComponent<Collider2D>().enabled = true;
            dishChoreButton.GetComponent<Collider2D>().enabled = true;
            garbageChoreButton.GetComponent<Collider2D>().enabled = true;
          
        }
        if (choreBusy == true)
        {
            sweepChoreButton.GetComponent<Collider2D>().enabled = false;
            dishChoreButton.GetComponent<Collider2D>().enabled = false;
            garbageChoreButton.GetComponent<Collider2D>().enabled = false;
        }
    }
}
