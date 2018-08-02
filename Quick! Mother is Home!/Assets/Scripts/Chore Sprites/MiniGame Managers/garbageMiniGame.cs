using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbageMiniGame : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;
    public float distance = 10;
    public float xMin = -2f;
    public float xMax = 2f;
    public float yMin = -4f;
    public float yMax = -4f;
    public int wadCount;
    public bool participatedInChore;
    // Use this for initialization
    void Start () {
        managerControllerScript = manager.GetComponent<ManagerController>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(transform.position.x, xMin, xMax);
        clampedPosition.y = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = clampedPosition;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePostion = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePostion);
        transform.position = objPosition;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "TrashWad")
        {
            wadCount = wadCount + 1;
            Destroy(coll.gameObject);
            if (participatedInChore == false)
            {
                managerControllerScript.participatedInChores = managerControllerScript.participatedInChores + 1;
                participatedInChore = true;
            }
        }
    }
}
