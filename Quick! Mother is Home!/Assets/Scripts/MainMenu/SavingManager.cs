using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SavingManager : MonoBehaviour {
    public static SavingManager control;

    public GameObject manager;
    public ManagerController managerControllerScript;

	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.playerSavings = managerControllerScript.playerSavings;
        data.responsibilityLevel = managerControllerScript.responsibilityLevel;
        data.choreSlot3Unlocked = managerControllerScript.choreSlot3UpgradeUnlocked;
        data.noChoreSlotsUnlocked = managerControllerScript.noExtraSlotsUnlocked;
        data.spongeUpgradeUnlocked = managerControllerScript.spongeActivated;
        data.broomUpgradeUnlocked = managerControllerScript.biggerBroomActivated;
        data.dustingUpgradeUnlocked = managerControllerScript.swiftyDusterActivated;
        data.trashUpgradeUnlocked = managerControllerScript.betterTrashBagsActivated;
        data.notFirstTimeRun = managerControllerScript.notFirstTimeRun;

        data.lemonEmpirePurchased = managerControllerScript.lemonadePurchased;
        data.lemonEmpireRevenue = managerControllerScript.lemonadeRevenue;
        data.lemonFlavorUpgradeCount = managerControllerScript.flavorLemonadeUpgradeCount;
        data.lemonFlavorUpgradePrice = managerControllerScript.flavorUpgradePrice;

        data.dustingChoreUnlocked = managerControllerScript.dustingChoreUnlocked;
        data.trashChoreUnlocked = managerControllerScript.trashChoreUnlocked;

        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game Saved!");
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            managerControllerScript.notFirstTimeRun = data.notFirstTimeRun;

            managerControllerScript.playerSavings = data.playerSavings;
            managerControllerScript.responsibilityLevel = data.responsibilityLevel;
            managerControllerScript.choreSlot3UpgradeUnlocked = data.choreSlot3Unlocked;
            managerControllerScript.noExtraSlotsUnlocked = data.noChoreSlotsUnlocked;

            managerControllerScript.dustingChoreUnlocked = data.dustingChoreUnlocked;
            managerControllerScript.trashChoreUnlocked = data.trashChoreUnlocked;

            managerControllerScript.spongeActivated = data.spongeUpgradeUnlocked;
            managerControllerScript.biggerBroomActivated = data.broomUpgradeUnlocked;
            managerControllerScript.swiftyDusterActivated = data.dustingUpgradeUnlocked;
            managerControllerScript.betterTrashBagsActivated = data.trashUpgradeUnlocked;

            managerControllerScript.lemonadePurchased = data.lemonEmpirePurchased;
            managerControllerScript.lemonadeRevenue = data.lemonEmpireRevenue;
            managerControllerScript.flavorLemonadeUpgradeCount = data.lemonFlavorUpgradeCount;
            managerControllerScript.flavorUpgradePrice = data.lemonFlavorUpgradePrice;

        }
        else
        {
            Debug.Log("no file to load");
        }
    }

    public void Delete()
    {
        try
        {
            File.Delete(Application.persistentDataPath + "/playerInfo.dat");
            Debug.Log("File Erased");
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
            Debug.Log("No");
        }
    }
}

[Serializable]
class PlayerData
{
    public bool notFirstTimeRun;
    public int playerSavings;
    public int responsibilityLevel;
    public bool noChoreSlotsUnlocked;
    public bool choreSlot3Unlocked;

    public bool dustingChoreUnlocked;
    public bool trashChoreUnlocked;

    public bool spongeUpgradeUnlocked;
    public bool broomUpgradeUnlocked;
    public bool dustingUpgradeUnlocked;
    public bool trashUpgradeUnlocked;

    public bool lemonEmpirePurchased;
    public int lemonEmpireRevenue;
    public int lemonFlavorUpgradeCount;
    public int lemonFlavorUpgradePrice;

}