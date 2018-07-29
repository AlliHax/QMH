using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOptionsButton : MonoBehaviour {
    public GameObject optionsHud;
    public GameObject StartButton;
    public GameObject creditButton;
    public GameObject optionsButton;
    public GameObject optionsMenuTitle;
    public GameObject optionsMenuSoundTitle;
    public GameObject optionsMenuSlider;

    private void OnMouseDown()
    {
        optionsMenuTitle.SetActive(false);
        optionsMenuSoundTitle.SetActive(false);
        optionsMenuSlider.SetActive(false);
        optionsHud.SetActive(false);
        optionsButton.GetComponent<Collider2D>().enabled = true;
        StartButton.GetComponent<Collider2D>().enabled = true;
        creditButton.GetComponent<Collider2D>().enabled = true;
    }
}
