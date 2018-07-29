using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionBuyButton : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;
    // Use this for initialization
    void Start () {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    private void Update()
    {
        if (managerControllerScript.viewingSpongeUpgradeDescription == true)
        {
            if(managerControllerScript.spongeActivated == true)
            {
                GetComponent<SpriteRenderer>().color = Color.grey;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        else if (managerControllerScript.viewingBroomUpgradeDescription == true)
        {
            if (managerControllerScript.biggerBroomActivated == true)
            {
                GetComponent<SpriteRenderer>().color = Color.grey;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        else if (managerControllerScript.viewingGarbageUpgradeDescription == true)
        {
            if (managerControllerScript.betterTrashBagsActivated == true)
            {
                GetComponent<SpriteRenderer>().color = Color.grey;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }

        else if (managerControllerScript.viewingExtraLockUpgradeDescription == true)
        {
            if (managerControllerScript.extraLockActivated == true)
            {
                GetComponent<SpriteRenderer>().color = Color.grey;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
    // Update is called once per frame
    private void OnMouseDown()
    {
        if (managerControllerScript.viewingSpongeUpgradeDescription == true)
        {
            if (managerControllerScript.spongeActivated == false)
            {
                if (managerControllerScript.playerSavings >= 40)
                {
                    
                    managerControllerScript.playerSavings = managerControllerScript.playerSavings - 40;
                    managerControllerScript.spongeActivated = true;
                    Debug.Log("New Sponge Added");
                }
                else
                {
                    managerControllerScript.displayNotEnoughMoney = true;
                    managerControllerScript.showDescriptionWindow = false;
                    managerControllerScript.notEnoughMoneyTextObject.SetActive(true);
                    managerControllerScript.notEnoughMoneyTitleObject.SetActive(true);
                }
            }
            else if (managerControllerScript.spongeActivated == true)
            {
                Debug.Log("You Already Own this Upgrade");
            }
        }
        else if (managerControllerScript.viewingBroomUpgradeDescription == true)
        {
            if (managerControllerScript.biggerBroomActivated == false)
            {
                if (managerControllerScript.playerSavings >= 100)
                {
                    GetComponent<SpriteRenderer>().color = Color.grey;
                    managerControllerScript.playerSavings = managerControllerScript.playerSavings - 100;
                    managerControllerScript.biggerBroomActivated = true;
                    Debug.Log("New Broom Added");
                }
                else
                {
                    managerControllerScript.displayNotEnoughMoney = true;
                    managerControllerScript.showDescriptionWindow = false;
                    managerControllerScript.notEnoughMoneyTextObject.SetActive(true);
                    managerControllerScript.notEnoughMoneyTitleObject.SetActive(true);
                }
            }
        }
        else if (managerControllerScript.viewingGarbageUpgradeDescription == true)
        {
            if (managerControllerScript.betterTrashBagsActivated == false)
            {
                if (managerControllerScript.playerSavings >= 200)
                {
                    GetComponent<SpriteRenderer>().color = Color.grey;
                    managerControllerScript.playerSavings = managerControllerScript.playerSavings - 200;
                    managerControllerScript.betterTrashBagsActivated = true;
                    Debug.Log("Nifty Bags Added");
                }
                else
                {
                    managerControllerScript.displayNotEnoughMoney = true;
                    managerControllerScript.showDescriptionWindow = false;
                    managerControllerScript.notEnoughMoneyTextObject.SetActive(true);
                    managerControllerScript.notEnoughMoneyTitleObject.SetActive(true);
                }
            }
        }
        else if (managerControllerScript.viewingExtraLockUpgradeDescription == true)
        {
            if (managerControllerScript.extraLockActivated == false)
            {
                if (managerControllerScript.playerSavings >= 100)
                {
                   
                    managerControllerScript.playerSavings = managerControllerScript.playerSavings - 100;
                    managerControllerScript.extraLockActivated = true;
                    Debug.Log("Extra Lock Added");
                }
                else
                {
                    managerControllerScript.displayNotEnoughMoney = true;
                    managerControllerScript.showDescriptionWindow = false;
                    managerControllerScript.notEnoughMoneyTextObject.SetActive(true);
                    managerControllerScript.notEnoughMoneyTitleObject.SetActive(true);
                }
            }
        }
        else if (managerControllerScript.viewingDusterUpgradeDescription == true)
        {
            if (managerControllerScript.swiftyDusterActivated == false)
            {
                if (managerControllerScript.playerSavings >= 150)
                {

                    managerControllerScript.playerSavings = managerControllerScript.playerSavings - 150;
                    managerControllerScript.swiftyDusterActivated = true;
                    Debug.Log("Swifty Duster Added");
                }
                else
                {
                    managerControllerScript.displayNotEnoughMoney = true;
                    managerControllerScript.showDescriptionWindow = false;
                    managerControllerScript.notEnoughMoneyTextObject.SetActive(true);
                    managerControllerScript.notEnoughMoneyTitleObject.SetActive(true);
                }
            }
        }
        else if (managerControllerScript.viewingChoreSlot3UpgradeDescription == true)
        {
            if (managerControllerScript.choreSlot3UpgradeUnlocked == false)
            {
                if (managerControllerScript.playerSavings >= 200)
                {

                    managerControllerScript.playerSavings = managerControllerScript.playerSavings - 200;
                    managerControllerScript.choreSlot3UpgradeUnlocked = true;
                    managerControllerScript.noExtraSlotsUnlocked = false;
                    Debug.Log("Chore Slot 3 Added");
                }
                else
                {
                    managerControllerScript.displayNotEnoughMoney = true;
                    managerControllerScript.showDescriptionWindow = false;
                    managerControllerScript.notEnoughMoneyTextObject.SetActive(true);
                    managerControllerScript.notEnoughMoneyTitleObject.SetActive(true);
                }
            }
        }
    }
}
