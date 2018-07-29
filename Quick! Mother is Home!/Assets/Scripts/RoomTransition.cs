using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour {
    public Transform cameraLocation;
    public GameObject manager;
    public ManagerController managerControllerScript;

    private void Start()
    {
        gameObject.SetActive(false);
        managerControllerScript = manager.GetComponent<ManagerController>();
    }
    private void Update()
    {
        if (managerControllerScript.choreBusy == true)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("Position Moving");
        Camera.main.transform.position = cameraLocation.position;
    }
}
