﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour {
    public GameObject OptionsHud;
    public GameObject StartButton;
    public GameObject creditButton;
    public GameObject optionsMenuTitle;
    public GameObject optionsMenuSoundTitle;
    public GameObject optionsMenuSlider;
    public GameObject resetButton;
    public GameObject soundEffectSlider;
    public GameObject soundEffectText;
    private void OnMouseDown()
    {
        OptionsHud.SetActive(true);
        optionsMenuTitle.SetActive(true);
        optionsMenuSoundTitle.SetActive(true);
        optionsMenuSlider.SetActive(true);
        resetButton.SetActive(true);
        soundEffectSlider.SetActive(true);
        soundEffectText.SetActive(true);
        gameObject.GetComponent<Collider2D>().enabled = false;
        StartButton.GetComponent<Collider2D>().enabled = false;
        creditButton.GetComponent<Collider2D>().enabled = false;

    }
}
