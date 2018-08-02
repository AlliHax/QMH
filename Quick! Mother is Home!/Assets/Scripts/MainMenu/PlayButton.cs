using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayButton : MonoBehaviour {
    public string sceneName;
    public GameObject manager;
    public ManagerController managerControllerScript;
    public GameObject savingManager;
    public SavingManager savingManagerScript;
	// Use this for initialization
	void Start () {
        managerControllerScript = manager.GetComponent<ManagerController>();
        savingManagerScript = savingManager.GetComponent<SavingManager>();
	}
	
	// Update is called once per frame
	void OnMouseDown() {
        savingManagerScript.Save();
        managerControllerScript.showStartMenu = false;
        managerControllerScript.BeginGamePlay();
	}
}
