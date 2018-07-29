using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerBehavior : MonoBehaviour {
    public float xMin;
    public float xMax;
    public float yMin = -1.0f;
    public float yMax = 0.85f;
    public float distance;

    public bool target1Triggered;
    public bool target2Triggered;
    public int successfulPlunge;

    // Use this for initialization
    void Start()
    {

    }

    public void Update()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(transform.position.x, xMin, xMax);
        clampedPosition.y = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = clampedPosition;

        CalculateStrokes();
    }

    private void OnMouseDrag()
    {
        Vector3 mousePostion = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePostion);
        transform.position = objPosition;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "plungePoint1")
        {
            target1Triggered = true;

        }
        if (other.gameObject.tag == "plungePoint2")
        {
            target2Triggered = true;

        }
    }

    public void CalculateStrokes()
    {
        if (target1Triggered == true && target2Triggered == true)
        {
            successfulPlunge = successfulPlunge + 1;
            target1Triggered = false;
            target2Triggered = false;
            Debug.Log(successfulPlunge);
        }
    }
}
