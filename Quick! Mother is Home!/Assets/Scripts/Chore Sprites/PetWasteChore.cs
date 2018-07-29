using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetWasteChore : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    public GameObject shovel;
    public GameObject scooperLimitBox;
    public GameObject poo;
    public int pooCount = 6;
    public int i = 0;
    public Transform[] pooSpawn;
    public GameObject bag;
    public Transform[] bagSpawn;
    public GameObject[] remainingComponents;

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
        if (timeStopped == false)
        {
            choreTime -= Time.deltaTime;
            CheckForTimeStopped();
        }
    }

    public void OnEnable()
    {
        managerControllerScript.backgroundImage.GetComponent<SpriteRenderer>().sprite = managerControllerScript.backyardBackground;
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
        StartPetWasteMiniGame();
    }

    private void StartPetWasteMiniGame()
    {
        shovel.SetActive(true);
        scooperLimitBox.SetActive(true);
        SpawnPoo();
        SpawnBag();
    }

    private void SpawnPoo()
    {
        List<Transform> freeSpawnPoints = new List<Transform>(pooSpawn);
        for (i = 0; i < pooCount; i++)
        {
            if (freeSpawnPoints.Count <= 0)
                return; // Not enough Spawn Points
            int index = Random.Range(0, freeSpawnPoints.Count);
            Transform pos = freeSpawnPoints[index];
            freeSpawnPoints.RemoveAt(index); //Remove the spawn point from temp list
            Instantiate(poo, pos.position, pos.rotation);

        }
    }

    private void SpawnBag()
    {
        int randomBagSpawn = Random.Range(0, bagSpawn.Length);
        Instantiate(bag, bagSpawn[randomBagSpawn].position, bagSpawn[randomBagSpawn].rotation);
    }

    private void CheckForTimeStopped()
    {
        if (choreTime <= 0)
        {
            StopPetWasteMiniGame();
        }
    }

    private void StopPetWasteMiniGame()
    {
        managerControllerScript.bag.SetActive(false);
        managerControllerScript.poo.SetActive(false);
        shovel.SetActive(false);
        scooperLimitBox.SetActive(false);
        DestroyRemainingComponents();
        UpdateManager();
        timeStopped = true;
        choreTime = baseChoreTime;
        NextChore();
    }

    private void DestroyRemainingComponents()
    {
        remainingComponents = GameObject.FindGameObjectsWithTag("bag");
        for (var i = 0; i < remainingComponents.Length; i++)
        {
            Destroy(remainingComponents[i]);
        }

        remainingComponents = GameObject.FindGameObjectsWithTag("poo");
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
