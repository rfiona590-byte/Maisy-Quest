using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject chickenPrefab;

    [SerializeField]
    private float minSpawnTime;

    [SerializeField]
    private float maxSpawnTime;

    private float timeRemaining;

    public List<GameObject> chickens = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        SetTimeUntillSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0 && chickens.Count <= 8)
        {
            spawnChicken();
            SetTimeUntillSpawn();
        }
    }
    //spawning chickens, spawns the chicken  prefab instance so everything assosiated with chicken happens with each  chicken spawned
    private void spawnChicken()
    {
        var chicken = Instantiate(chickenPrefab, transform.position, Quaternion.identity) as GameObject;
        chickens.Add(chicken);

        if (ChickenHealth.chickenDeath == true)
        {
            chickens.RemoveAt(1);
        }
    }
    //picks a random number to wait to spawn chicken out of the set max and min spawn time
    private void SetTimeUntillSpawn()
    {
        timeRemaining = Random.Range(minSpawnTime, maxSpawnTime);
    }
}

