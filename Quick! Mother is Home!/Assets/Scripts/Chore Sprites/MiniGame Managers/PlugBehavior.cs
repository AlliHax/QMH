using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugBehavior : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    public VacuumingChore vacuumChoreScript;
    public GameObject vacuumChoreObject;
    public GameObject target;
    public float distance;

    // Use this for initialization
    void Start()
    {
        vacuumChoreScript = vacuumChoreObject.GetComponent<VacuumingChore>();
        managerControllerScript = manager.GetComponent<ManagerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vacuumChoreScript.spawnedPlug == true)
        {
            FaceOutlet();
        }
    }

    public void FaceOutlet()
    {
        target = vacuumChoreScript.spawnedOutlet;
        Quaternion rotation = Quaternion.LookRotation
        (target.transform.position - transform.position, transform.TransformDirection(Vector3.back));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "outlet")
        {
            vacuumChoreScript.spawnedPlug = false;
            vacuumChoreScript.outlet.SetActive(true);
            vacuumChoreScript.spawnAgain = true;
            Debug.Log("Plugged in!");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
