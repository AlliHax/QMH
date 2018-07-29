using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransitionToKitchen : MonoBehaviour {
    public Transform cameraLocation;

    private void OnMouseDown()
    {
        Debug.Log("Position Moving");
        Camera.main.transform.position = cameraLocation.position;
    }
}
