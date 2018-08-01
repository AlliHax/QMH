using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xButtonForConfirm : MonoBehaviour {
    public GameObject slider;
    public GameObject optionsTitle;
    public GameObject musicVolumeTitle;
    public GameObject checkTitle;
    public GameObject checkExplaination;
    public GameObject checkButton;
    public GameObject normConfirmButton;

    private void OnMouseDown()
    {
        slider.SetActive(true);
        optionsTitle.SetActive(true);
        musicVolumeTitle.SetActive(true);
        checkExplaination.SetActive(false);
        checkTitle.SetActive(false);
        checkButton.SetActive(false);
        normConfirmButton.SetActive(true);
        gameObject.SetActive(false);
    }
}
