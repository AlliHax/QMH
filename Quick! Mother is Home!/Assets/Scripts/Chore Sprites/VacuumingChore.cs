using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumingChore : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    public GameObject plug;
    public GameObject outlet;
    public GameObject[] remainingComponents;

    public Transform[] leftSpawnPoints;
    public Transform[] rightSpawnPoints;
    public Transform outletRotation;

    public GameObject spawnedOutlet;
    public bool checkForOutlet;
    public bool spawnedPlug;
    public bool spawnAgain;

    public float baseChoreTime = 5.0f;
    public float choreTime;
    public bool timeStopped;

    public GameObject countDownObject;


    // Use this for initialization
    void Start()
    {
        managerControllerScript = manager.GetComponent<ManagerController>();
        timeStopped = true;
        choreTime = baseChoreTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkForOutlet == true)
        {

        }
        if (spawnAgain == true)
        {
            SpawnVacuumComponents();
        }
        if (timeStopped == false)
        {
            choreTime -= Time.deltaTime;
            CheckForTimeStopped();
        }
    }

    public void OnEnable()
    {
        managerControllerScript.backgroundImage.GetComponent<SpriteRenderer>().sprite = managerControllerScript.livingRoomBackground;
        Debug.Log("Vacuuming Started");
        countDownObject.SetActive(true);
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 2f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        countDownObject.gameObject.SetActive(false);
        Time.timeScale = 1;
        timeStopped = false;
        Debug.Log("spawning");
        SpawnVacuumComponents();
    }

    private void SpawnVacuumComponents()
    {
        Debug.Log("spawning");
        spawnAgain = false;
        int roll = Random.Range(1, 3);
        Debug.Log(roll);
        if (roll == 1)
        {
            int plugSpawnPoint = Random.Range(0, leftSpawnPoints.Length);
            Instantiate(plug, leftSpawnPoints[plugSpawnPoint].position, plug.transform.rotation);

            int outletSpawnPoint = Random.Range(0, rightSpawnPoints.Length);
            Instantiate(outlet, rightSpawnPoints[outletSpawnPoint].position, outlet.transform.rotation);
        }
        if (roll == 2)
        {
            int plugSpawnPoint = Random.Range(0, rightSpawnPoints.Length);
            Instantiate(plug, rightSpawnPoints[plugSpawnPoint].position, plug.transform.rotation);

            int outletSpawnPoint = Random.Range(0, leftSpawnPoints.Length);
            Instantiate(outlet, leftSpawnPoints[outletSpawnPoint].position, outlet.transform.rotation);
        }
        outlet.SetActive(false);
        AssignOutlet();
        spawnedPlug = true;
    }
    private void AssignOutlet()
    {
        spawnedOutlet = GameObject.FindGameObjectWithTag("outlet");
    }

    private void CheckForTimeStopped()
    {
        if (choreTime <= 0)
        {
            StopVacuumMiniGame();
        }
    }

    private void StopVacuumMiniGame()
    {
        managerControllerScript.plug.SetActive(false);
        managerControllerScript.outlet.SetActive(false);
        DestroyRemainingComponents();
        UpdateManager();
        spawnedPlug = false;
        timeStopped = true;
        choreTime = baseChoreTime;
        NextChore();
    }

    private void DestroyRemainingComponents()
    {
        remainingComponents = GameObject.FindGameObjectsWithTag("plug");
        for (var i = 0; i < remainingComponents.Length; i++)
        {
            Destroy(remainingComponents[i]);
        }

        remainingComponents = GameObject.FindGameObjectsWithTag("outlet");
        for (var i = 0; i < remainingComponents.Length; i++)
        {
            Destroy(remainingComponents[i]);
        }

    }

    private void UpdateManager()
    {
        managerControllerScript.choreBusy = false;
        managerControllerScript.choresCompleted = managerControllerScript.choresCompleted + 1;
    }

    private void NextChore()
    {

        if (managerControllerScript.activateChoreOne == true)
        {
            managerControllerScript.activateChoreOne = false;
            managerControllerScript.activateChoreTwo = true;
        }
        else if (managerControllerScript.activateChoreTwo == true)
        {
            managerControllerScript.activateChoreTwo = false;
            managerControllerScript.activateChoreThree = true;
        }
        else if (managerControllerScript.activateChoreThree == true)
        {
            managerControllerScript.activateChoreThree = false;
        }
    }
}
