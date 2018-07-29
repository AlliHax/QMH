using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnChore : MonoBehaviour {
    public GameObject manager;
    public ManagerController managerControllerScript;

    public float baseChoreTime = 5.0f;
    public float choreTime;
    public bool timeStopped;

    public Transform[] grassSpawnPoints;
    public GameObject grass;
    public GameObject rock;
    public Transform[] rockSpawn;
    public int rockCount;
    public int i = 0;
    public GameObject[] remainingComponents;

    public GameObject mower;
    public GameObject mower1;
    public GameObject mower2;
    public GameObject mower3;
    public GameObject mower4;
    public GameObject mower5;

    public bool mower1Activated;
    public bool mower1Finished;
    public bool mower2Activated;
    public bool mower2Finished;
    public bool mower3Activated;
    public bool mower3Finished;
    public bool mower4Activated;
    public bool mower4Finished;
    public bool mower5Activated;
    public bool mower5Finished;

    public Transform mower1StartPosition1;
    public Transform mower1StartPosition2;
    public GameObject mower1FinishPosition1;
    public GameObject mower1FinishPosition2;

    public Transform mower2StartPosition1;
    public Transform mower2StartPosition2;
    public GameObject mower2FinishPosition1;
    public GameObject mower2FinishPosition2;

    public Transform mower3StartPosition1;
    public Transform mower3StartPosition2;
    public GameObject mower3FinishPosition1;
    public GameObject mower3FinishPosition2;

    public Transform mower4StartPosition1;
    public Transform mower4StartPosition2;
    public GameObject mower4FinishPosition1;
    public GameObject mower4FinishPosition2;

    public Transform mower5StartPosition1;
    public Transform mower5StartPosition2;
    public GameObject mower5FinishPosition1;
    public GameObject mower5FinishPosition2;

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
        if (mower1Finished == true)
        {
            SpawnNextMower();
        }
        else if (mower2Finished == true)
        {
            SpawnNextMower();
        }
        else if (mower3Finished == true)
        {
            SpawnNextMower();
        }
        else if (mower4Finished == true)
        {
            SpawnNextMower();
        }
        else if (mower5Finished == true)
        {
            Debug.Log("End Game");
        }

        if (timeStopped == false)
        {
            choreTime -= Time.deltaTime;
            CheckForTimeStopped();
        }
    }

    public void OnEnable()
    {
        managerControllerScript.backgroundImage.GetComponent<SpriteRenderer>().sprite = managerControllerScript.backyardBackground;
        Debug.Log("Starting Lawn Chore");
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
        StartLawnMiniGame();
    }

    private void StartLawnMiniGame()
    {
        mower.SetActive(true);
        Debug.Log("Picking Mower1Position");
        PickMower1Position();
        mower1Activated = true;
        SpawnGrass();
        SpawnRocks();
    }

    private void SpawnGrass()
    {
        foreach (Transform grassSpawn in grassSpawnPoints)
        {
            Instantiate(grass, grassSpawn.position, grassSpawn.rotation);
        }
    }

    private void SpawnRocks()
    {
        rockCount = 3;
        List<Transform> freeSpawnPoints = new List<Transform>(rockSpawn);
        for (i = 0; i < rockCount; i++)
        {
            if(freeSpawnPoints.Count <= 0)
            {
                return;
            }
            int index = Random.Range(0, freeSpawnPoints.Count);
            Transform pos = freeSpawnPoints[index];
            freeSpawnPoints.RemoveAt(index); //Remove the spawn point from temp list
            Instantiate(rock, pos.position, pos.rotation);
        }
    }

    private void SpawnNextMower()
    {
        if (mower1Activated == true)
        {
            Debug.Log("Picking Second Mower");
            PickMower2Position();
            Destroy(mower1);
            mower1Finished = false;
            mower1Activated = false;
            mower2Activated = true;
        }
        else if (mower2Activated == true)
        {
            PickMower3Position();
            Destroy(mower2);
            mower2Finished = false;
            mower2Activated = false;
            mower3Activated = true;
        }
        else if (mower3Activated == true)
        {
            PickMower4Position();
            Destroy(mower3);
            mower3Finished = false;
            mower3Activated = false;
            mower4Activated = true;
        }
        else if (mower4Activated == true)
        {
            Debug.Log("Picking Last Mower");
            PickMower5Position();
            Destroy(mower4);
            mower4Activated = false;
            mower5Activated = true;
        }


    }

    private void PickMower1Position()
    {
        int positionRoll = Random.Range(1, 3);
        if (positionRoll == 1)
        {
            var newMower1 = (GameObject)Instantiate(mower, mower1StartPosition1.position, mower1StartPosition1.rotation);
            newMower1.name = "mower1";
            mower1FinishPosition2.SetActive(true);
            mower1 = newMower1;
            
        }
        else if (positionRoll == 2)
        {
            var newMower1 = (GameObject)Instantiate(mower, mower1StartPosition2.position, mower1StartPosition2.rotation);
            newMower1.name = "mower1";
            mower1FinishPosition1.SetActive(true);
            mower1 = newMower1;
            newMower1.transform.Rotate(0, 180, 0);
        }
    }

    private void PickMower2Position()
    {
        int positionRoll = Random.Range(1, 3);
        if (positionRoll == 1)
        {
            var newMower2 = (GameObject)Instantiate(mower, mower2StartPosition1.position, mower2StartPosition1.rotation);
            newMower2.name = "mower2";
            mower2FinishPosition2.SetActive(true);
            mower2 = newMower2;
        }
        else if (positionRoll == 2)
        {
            var newMower2 = (GameObject)Instantiate(mower, mower2StartPosition2.position, mower2StartPosition2.rotation);
            newMower2.name = "mower2";
            mower2FinishPosition1.SetActive(true);
            mower2 = newMower2;
            newMower2.transform.Rotate(0, 180, 0);
        }
    }

    private void PickMower3Position()
    {
        int positionRoll = Random.Range(1, 3);
        if (positionRoll == 1)
        {
            var newMower3 = (GameObject)Instantiate(mower, mower3StartPosition1.position, mower3StartPosition1.rotation);
            newMower3.name = "mower3";
            mower3FinishPosition2.SetActive(true);
            mower3 = newMower3;
        }
        else if (positionRoll == 2)
        {
            var newMower3 = (GameObject)Instantiate(mower, mower3StartPosition2.position, mower3StartPosition2.rotation);
            newMower3.name = "mower3";
            mower3FinishPosition1.SetActive(true);
            mower3 = newMower3;
            newMower3.transform.Rotate(0, 180, 0);
        }
    }

    private void PickMower4Position()
    {
        int positionRoll = Random.Range(1, 3);
        if (positionRoll == 1)
        {
            var newMower4 = (GameObject)Instantiate(mower, mower4StartPosition1.position, mower4StartPosition1.rotation);
            newMower4.name = "mower4";
            mower4FinishPosition2.SetActive(true);
            mower4 = newMower4;
        }
        else if (positionRoll == 2)
        {
            var newMower4 = (GameObject)Instantiate(mower, mower4StartPosition2.position, mower4StartPosition2.rotation);
            newMower4.name = "mower4";
            mower4FinishPosition1.SetActive(true);
            mower4 = newMower4;
            newMower4.transform.Rotate(0, 180, 0);
        }
    }

    private void PickMower5Position()
    {
        int positionRoll = Random.Range(1, 3);
        if (positionRoll == 1)
        {
            var newMower5 = (GameObject)Instantiate(mower, mower5StartPosition1.position, mower5StartPosition1.rotation);
            newMower5.name = "mower5";
            mower5FinishPosition2.SetActive(true);
            mower5 = newMower5;
        }
        else if (positionRoll == 2)
        {
            var newMower5 = (GameObject)Instantiate(mower, mower5StartPosition2.position, mower5StartPosition2.rotation);
            newMower5.name = "mower5";
            mower5FinishPosition1.SetActive(true);
            mower5 = newMower5;
            newMower5.transform.Rotate(0, 180, 0);
        }
    }

    private void CheckForTimeStopped()
    {
        if (choreTime <= 0)
        {
            StopLawnMiniGame();
        }
    }

    private void StopLawnMiniGame()
    {
        managerControllerScript.mower.SetActive(false);
        managerControllerScript.unCutGrass.SetActive(false);
        managerControllerScript.cutGrass.SetActive(false);
        managerControllerScript.rock.SetActive(false);
        DestroyLawnObjects();
        DeactivateFinished();
        UpdateManager();
        timeStopped = true;
        choreTime = baseChoreTime;
        NextChore();
    }

    private void DestroyLawnObjects()
    {
        remainingComponents = GameObject.FindGameObjectsWithTag("grass");
        for (var i = 0; i < remainingComponents.Length; i++)
        {
            Destroy(remainingComponents[i]);
        }

        remainingComponents = GameObject.FindGameObjectsWithTag("rock");
        for (var i = 0; i < remainingComponents.Length; i++)
        {
            Destroy(remainingComponents[i]);
        }

        remainingComponents = GameObject.FindGameObjectsWithTag("mower");
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
        Debug.Log("Ending Game");
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

    private void DeactivateFinished()
    {
        mower1FinishPosition1.SetActive(false);
        mower1FinishPosition2.SetActive(false);
        mower2FinishPosition1.SetActive(false);
        mower2FinishPosition2.SetActive(false);
        mower3FinishPosition1.SetActive(false);
        mower3FinishPosition2.SetActive(false);
        mower4FinishPosition1.SetActive(false);
        mower4FinishPosition2.SetActive(false);
        mower5FinishPosition1.SetActive(false);
        mower5FinishPosition2.SetActive(false);
    }
}
