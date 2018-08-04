using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpireUpgradeBuyButtons : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;
    public GameObject lemonadeStandObject;
    public GameObject previewLemonadeStandObject;
    public Sprite lemonadeSpriteStart;
    public Sprite lemonadeSpriteUpdate1;
    public AudioClip buttonPushedSound;
    public AudioSource soundEffectSource;


    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
        if (managerControllerScript.notFirstTimeRun == false)
        {
            managerControllerScript.flavorUpgradePrice = 50;
        }
    }

    public void Update()
    {
        if (managerControllerScript.totalLemonadeStandUpgrades >= 5)
        {
            lemonadeStandObject.GetComponent<SpriteRenderer>().sprite = lemonadeSpriteUpdate1;
            previewLemonadeStandObject.GetComponent<SpriteRenderer>().sprite = lemonadeSpriteUpdate1;
        }
    }
    // Update is called once per frame
    private void OnMouseDown()
    {
        if(gameObject.name == "flavor_Buy_Button")
        {
            if (managerControllerScript.playerSavings >= managerControllerScript.flavorUpgradePrice)
            {
                soundEffectSource.clip = buttonPushedSound;
                soundEffectSource.Play();
                managerControllerScript.playerSavings = managerControllerScript.playerSavings - managerControllerScript.flavorUpgradePrice;
                managerControllerScript.flavorLemonadeUpgradeCount = managerControllerScript.flavorLemonadeUpgradeCount + 1;
                managerControllerScript.lemonadeRevenue = managerControllerScript.lemonadeRevenue + (managerControllerScript.flavorLemonadeUpgradeCount * 3);
                managerControllerScript.flavorUpgradePrice = managerControllerScript.flavorUpgradePrice + 50;
            }
        }
    }
}
