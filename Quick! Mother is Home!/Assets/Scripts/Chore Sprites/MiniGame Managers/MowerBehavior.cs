using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MowerBehavior : MonoBehaviour {
    public GameObject lawnChoreManager;
    public LawnChore lawnChoreScript;
    public float distance = 10;
    public float xMin = -2;
    public float xMax = 2;
    public float mower1yMin;
    public float mower1yMax;

    public float mower2yMin;
    public float mower2yMax;

    public float mower3yMin;
    public float mower3yMax;

    public float mower4yMin;
    public float mower4yMax;

    public float mower5yMin;
    public float mower5yMax;

    public Transform startPosition;
    public Rigidbody2D rb;
    public bool mouseDragActivated;


    // Use this for initialization
    void Start()
    {
        lawnChoreScript = lawnChoreManager.GetComponent<LawnChore>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "mower1")
        {
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(transform.position.x, xMin, xMax);
            clampedPosition.y = Mathf.Clamp(transform.position.y, mower1yMin, mower1yMax);
            transform.position = clampedPosition;
        }
        if (gameObject.name == "mower2")
        {
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(transform.position.x, xMin, xMax);
            clampedPosition.y = Mathf.Clamp(transform.position.y, mower2yMin, mower2yMax);
            transform.position = clampedPosition;
        }
        if (gameObject.name == "mower3")
        {
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(transform.position.x, xMin, xMax);
            clampedPosition.y = Mathf.Clamp(transform.position.y, mower3yMin, mower3yMax);
            transform.position = clampedPosition;
        }
        if (gameObject.name == "mower4")
        {
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(transform.position.x, xMin, xMax);
            clampedPosition.y = Mathf.Clamp(transform.position.y, mower4yMin, mower4yMax);
            transform.position = clampedPosition;
        }
        if (gameObject.name == "mower5")
        {
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(transform.position.x, xMin, xMax);
            clampedPosition.y = Mathf.Clamp(transform.position.y, mower5yMin, mower5yMax);
            transform.position = clampedPosition;
        }
    }

    private void FixedUpdate()
    {
        if (mouseDragActivated == true)
        {
            Vector3 mousePostion = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePostion);
            rb.MovePosition(objPosition);

            mouseDragActivated = false;
        }
    }

    private void OnMouseDrag()
    {
        mouseDragActivated = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "mower1Finish")
        {
            Debug.Log("collided with finish1");
            lawnChoreScript.mower1Finished = true;
        }
        else if (other.gameObject.tag == "mower2Finish")
        {
            lawnChoreScript.mower2Activated = true;
            lawnChoreScript.mower2Finished = true;
        }
        else if (other.gameObject.tag == "mower3Finish")
        {
            lawnChoreScript.mower3Activated = true;
            lawnChoreScript.mower3Finished = true;
        }
        else if (other.gameObject.tag == "mower4Finish")
        {
            Debug.Log("Hit Finish 4");
            lawnChoreScript.mower4Activated = true;
            lawnChoreScript.mower4Finished = true;
        }
        else if (other.gameObject.tag == "mower5Finish")
        {
            lawnChoreScript.mower5Finished = true;
            lawnChoreScript.mower5Activated = true;
            Debug.Log("Lawn Game End");
        }

    }
}
