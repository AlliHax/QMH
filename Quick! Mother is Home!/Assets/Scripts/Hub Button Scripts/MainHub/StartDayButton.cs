using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDayButton : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;
    public Transform cameraLocation;
    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    void OnMouseDown()
    {
        managerControllerScript.savingManagerScript.Save();
        managerControllerScript.showStickyNote = true;
        managerControllerScript.delayCountDownStart = true;
        managerControllerScript.dayStart = true;
        managerControllerScript.showPlayerStats = false;
        Camera.main.transform.position = cameraLocation.position;
        managerControllerScript.dishMiniGameReady = true;
        managerControllerScript.diryDish.SetActive(true);
        managerControllerScript.trashWad.SetActive(true);
        managerControllerScript.bananaPeel.SetActive(true);
        managerControllerScript.whiteSock.SetActive(true);
        managerControllerScript.blueSock.SetActive(true);
        managerControllerScript.purpleSock.SetActive(true);
        managerControllerScript.dustBallOne.SetActive(true);
        managerControllerScript.dustBallTwo.SetActive(true);
        managerControllerScript.dustBallThree.SetActive(true);
        managerControllerScript.dustBallFour.SetActive(true);
        managerControllerScript.plug.SetActive(true);
        managerControllerScript.outlet.SetActive(true);
        managerControllerScript.mower.SetActive(true);
        managerControllerScript.cutGrass.SetActive(true);
        managerControllerScript.unCutGrass.SetActive(true);
        managerControllerScript.rock.SetActive(true);
        managerControllerScript.poo.SetActive(true);
        managerControllerScript.bag.SetActive(true);
        managerControllerScript.choresNeedAssignment = true;
        managerControllerScript.beginChoreOrder = true;
    }
}
