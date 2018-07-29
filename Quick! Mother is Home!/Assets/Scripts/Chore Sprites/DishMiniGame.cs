using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishMiniGame : MonoBehaviour {
    public Transform[] dishSpawnPoints;
    public GameObject dirtyDish;
    public GameObject dishButton;
    public DishChore dishChoreScript;
    public float spawnDishStartTime = .5f;
    public float spawnDishWaitTime = 1f;
    public int i = 0;
    public int dishCount = 3;

    // Use this for initialization
    void Start () {
        
    }

    private void OnEnable()
    {
        Debug.Log("enabled");
        dishChoreScript = dishButton.GetComponent<DishChore>();
        //CreateDishes();
        InvokeRepeating("CreateDishes", spawnDishStartTime, spawnDishWaitTime);
    }
    private void CreateDishes()
    {
        List<Transform> freeSpawnPoints = new List<Transform>(dishSpawnPoints);
        for (i=0; i<dishCount; i++)
        {
            if (freeSpawnPoints.Count <= 0)
            {
                return;
            }
            int index = Random.Range(0, freeSpawnPoints.Count);
            Transform pos = freeSpawnPoints[index];
            freeSpawnPoints.RemoveAt(index);
            Instantiate(dirtyDish, pos.position, pos.rotation);
        }
    }
}
