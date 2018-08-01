using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayButton : MonoBehaviour {
    public string sceneName;
    public GameObject manager;
    public GameObject savingManager;
    public SavingManager savingManagerScript;
	// Use this for initialization
	void Start () {
        savingManagerScript = savingManager.GetComponent<SavingManager>();
	}
	
	// Update is called once per frame
	void OnMouseDown() {
        Destroy(manager);
        Destroy(savingManager);
        SceneManager.LoadScene(sceneName);
        savingManagerScript.Save();
	}
}
