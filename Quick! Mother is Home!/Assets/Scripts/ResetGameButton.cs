using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameButton : MonoBehaviour {
    public SavingManager savingManagerScript;
    public GameObject savingManager;
	// Use this for initialization
	void Start () {
        savingManagerScript = savingManager.GetComponent<SavingManager>();
	}

    private void OnMouseDown()
    {
        savingManagerScript.Delete();
    }
}
