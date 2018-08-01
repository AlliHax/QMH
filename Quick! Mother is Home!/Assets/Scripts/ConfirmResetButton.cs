using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmResetButton : MonoBehaviour {
    public SavingManager savingManagerScript;
    public GameObject savingManager;

    // Use this for initialization
    void Start()
    {
        savingManagerScript = savingManager.GetComponent<SavingManager>();
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    // Deletes all save data
    private void OnMouseDown()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
        savingManagerScript.Delete();
    }
}
