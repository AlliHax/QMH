using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmResetButton : MonoBehaviour {
    public SavingManager savingManagerScript;
    public GameObject savingManager;
    public GameObject optionsHud;
    public GameObject checkTitle;
    public GameObject checkExplain;
    public GameObject StartButton;
    public GameObject creditButton;
    public GameObject optionsButton;

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
        optionsHud.SetActive(false);
        checkExplain.SetActive(false);
        checkTitle.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        optionsButton.GetComponent<Collider2D>().enabled = true;
        StartButton.GetComponent<Collider2D>().enabled = true;
        creditButton.GetComponent<Collider2D>().enabled = true;
        gameObject.SetActive(false);

    }
}
