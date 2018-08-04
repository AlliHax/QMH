using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseNotEnoughMoneyWindow : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;
    public AudioClip buttonPushedSound;
    public AudioSource soundEffectSource;

    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
        soundEffectSource.clip = buttonPushedSound;
    }

    void OnMouseDown()
    {
        soundEffectSource.Play();
        managerControllerScript.displayNotEnoughMoney = false;
        managerControllerScript.showDescriptionWindow = true;
        managerControllerScript.notEnoughMoneyWindow.SetActive(false);
        managerControllerScript.notEnoughMoneyTextObject.SetActive(false);
        managerControllerScript.notEnoughMoneyTitleObject.SetActive(false);
    }
}
