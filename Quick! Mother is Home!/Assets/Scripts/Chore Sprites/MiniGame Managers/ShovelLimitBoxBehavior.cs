using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelLimitBoxBehavior : MonoBehaviour {
    public GameObject shovelManager;
    public ShovelBehavior shovelBehaviorScript;
    public GameObject shovel;
    public GameObject poo;
    public Sprite emptyShovel;
    public int distance;
    // Use this for initialization

    void Start()
    {
        shovelBehaviorScript = shovelManager.GetComponent<ShovelBehavior>();
    }

    // Update is called once per frame
    void OnMouseDrag()
    {

        shovel.SetActive(true);
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        shovel.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void OnMouseUp()
    {
        shovel.SetActive(false);
        if (shovelBehaviorScript.shovelFull == true)
        {
            Instantiate(poo, gameObject.transform.position, gameObject.transform.rotation);
            shovel.GetComponent<SpriteRenderer>().sprite = emptyShovel;
            shovelBehaviorScript.shovelFull = false;
        }
    }
}
