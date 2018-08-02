using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepMiniGame : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;
    public GameObject sweepChoreObject;
    public SweepChore sweepChoreScript;
    public int sweepSwipe;
    public Transform startPosition;

    public AudioClip sweepSound;
    public AudioSource soundSource;

    public float distance = 10;
    public float xMin = -2f;
    public float xMax = 2f;
    public float yMin = -4f;
    public float yMax = -4f;

    public bool target1Triggered;
    public bool target2Triggered;
    private void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
        sweepChoreScript = sweepChoreObject.GetComponent<SweepChore>();
        sweepSwipe = 0;
        soundSource.clip = sweepSound;
    }

    private void OnEnable()
    {
        transform.position = startPosition.transform.position;
    }
    public void Update()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(transform.position.x, xMin, xMax);
        clampedPosition.y = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = clampedPosition;

        CalculateEarnings();

    }
    private void OnMouseDrag()
    {
        Vector3 mousePostion = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePostion);
        transform.position = objPosition;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "SweepLocation1")
        {
            target1Triggered = true;
            soundSource.Play();

        }
        if (coll.gameObject.tag == "SweepLocation2")
        {
            target2Triggered = true;

        }
    }

    //Calculated how much the player has earned in sweeping mini game, based on how many times they were able to swipe the broom
    public void CalculateEarnings()
    {
        if (target1Triggered == true && target2Triggered == true)
        {
            sweepSwipe = sweepSwipe + 1;
            target1Triggered = false;
            target2Triggered = false;
            
        }
    }
}
