using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] GameObject[] resourcePrefabs;
    [SerializeField] Collider spawnPerimeter;
    [SerializeField] TMP_Text waveText;

    //Spawner Values
    bool canSpawn;
    bool inWave;
    int currentWave;
    int crowdSize;
    int waveScale;

    [SerializeField] float scaleFactor;
    [SerializeField] float spawnInterval;
    [SerializeField] int crowdSpread;
    [SerializeField] int maxCrowd;
    [SerializeField] int waveTime;

    [SerializeField] int woodMax;
    List<GameObject> woodCount = new List<GameObject>(); //THIS IS SUUUUUUUUUUUUPER BAD 


    // Start is called before the first frame update
    void Start()
    {
        currentWave = 0;
        waveScale = 1;
        canSpawn = true;
        inWave = false;


        waveText.text = currentWave.ToString();

        Invoke("StartWave", 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inWave)
        {
            if (canSpawn)
            {
                SpawnEnemy(enemyPrefabs[0]);
            }
        }
    }

    void StartWave()
    {
        //THIS IS ALSO SUPER FRICKING BAD GOD PLEASE FORGIVE ME FOR MY SINS
        for (int i = 0;i < woodCount.Count - 1; i++)
        {
            if (woodCount[i] == null)
            {
                woodCount.RemoveAt(i); 
            }
        }
        while (woodCount.Count < woodMax)
        {
            Vector3 pos = GetRandomLoc();
            pos.y = 0;
            woodCount.Add(Instantiate(resourcePrefabs[0], pos, Quaternion.identity));
        }
        waveText.text = "Wave: " + currentWave.ToString();
        inWave = true;
        Invoke("EndWave", waveTime);
    }

    void EndWave()
    {
        waveText.text = "CALM";
        inWave = false;
        currentWave++;
        spawnInterval = spawnInterval * Mathf.Pow(scaleFactor, -currentWave); 
        Invoke("StartWave", 20);
    }

    void SpawnEnemy(GameObject enemy)
    {
        canSpawn = false;
        crowdSize = Random.Range(1, maxCrowd);
        Vector3 spawnCenter = GetRandomLoc();
        for (int i = 0; i < crowdSize; i++)
        {
            spawnCenter += new Vector3(Random.Range(-crowdSpread, crowdSpread), 0, Random.Range(-crowdSpread, crowdSpread));
            Instantiate(enemy, spawnCenter, Quaternion.identity, this.transform);
        }
        Invoke("ResetSpawnInterval", spawnInterval);
    }

    void ResetSpawnInterval()
    {
        canSpawn = true;
    }

    Vector3 GetRandomLoc()
    {
        Vector3 colliderSize = spawnPerimeter.bounds.size;

        float randX = Random.Range(-colliderSize.x / 2f, colliderSize.x / 2f);
        float randZ = Random.Range(-colliderSize.z / 2f, colliderSize.z / 2f);

        return spawnPerimeter.transform.position + new Vector3(randX, 0, randZ);
    }
}
