using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMiniGameManager : MonoBehaviour {
    public Transform[] spawnPoints;
    public GameObject trashWad;
    public GameObject garbageButton;
    public GameObject bananaPeel;
    public TakeOutGarbage garbageChoreScript;
    public float startTrashSpawnTime = .5f;
    public float startBananaSpawnTime = .8f;
    public float trashSpawnWaitTime = .8f;
    public float bananaSpawnWaitTime = 1.4f;

    private void OnEnable()
    {
        garbageChoreScript = garbageButton.GetComponent<TakeOutGarbage>();
        InvokeRepeating("CreateTrashWads", startTrashSpawnTime, trashSpawnWaitTime);
        InvokeRepeating("CreateBananaPeels", startBananaSpawnTime, bananaSpawnWaitTime);
    }
    private void CreateTrashWads()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(trashWad, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
    private void CreateBananaPeels()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(bananaPeel, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
