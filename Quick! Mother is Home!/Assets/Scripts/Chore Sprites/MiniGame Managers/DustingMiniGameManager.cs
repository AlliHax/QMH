using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustingMiniGameManager : MonoBehaviour {
    public GameObject duster;
    public int distance;
    // Use this for initialization

    void Start()
    {

    }

    // Update is called once per frame
    void OnMouseDrag()
    {

        duster.SetActive(true);
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        duster.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void OnMouseUp()
    {
        duster.SetActive(false);
    }
}
