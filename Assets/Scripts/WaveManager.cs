using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    [SerializeField] private List<Spawner> spawners = new List<Spawner>();

    [SerializeField] int waveTime;
    [SerializeField] int downTime;
    [SerializeField] float spawnInterval;
    [SerializeField] float scaleFactor;

    bool canSpawn;
    bool inWave; 
    int currentWave;

    // Start is called before the first frame update
    void Start()
    {
        
        currentWave = 0;
        scaleFactor = 1;
        canSpawn = true;
        inWave = false;

        Invoke("StartWave", downTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inWave)
        {
            if (canSpawn)
            {
                spawners[0].SpawnEntity();
                canSpawn = false;
                Invoke("ResetSpawnInterval", spawnInterval);
            }
        }
    }

    void StartWave()
    {
        inWave = true;
        Invoke("EndWave", waveTime);
    }
    void EndWave()
    {
        inWave = false;
        currentWave++;
        spawnInterval = spawnInterval * Mathf.Pow(scaleFactor, -currentWave); 
        Invoke("StartWave", downTime);
    }
    void ResetSpawnInterval()
    {
        canSpawn = true;
    }
}
