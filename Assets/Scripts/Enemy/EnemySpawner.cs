using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner: Spawner 
{
    [SerializeField] int crowdSpread;
    [SerializeField] int maxCrowd;

    PlayerSubject playerSubject;

    //Spawner Values
    int crowdSize;

    // Start is called before the first frame update
    void Start()
    {
        playerSubject = GameObject.Find("Player").GetComponent<Player>().playerSubject;
        entityPool = GeneratePoolEntities(entityPrefabs[0], 300);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override Vector3 GetRandomLoc()
    {
        Vector3 colliderSize = spawnPerimeter.bounds.size;

        float randX = Random.Range(-colliderSize.x / 2f, colliderSize.x / 2f);
        float randZ = Random.Range(-colliderSize.z / 2f, colliderSize.z / 2f);

        return spawnPerimeter.transform.position + new Vector3(randX, 0, randZ);
    }

    public override void SpawnEntity()
    {
        canSpawn = false;
        crowdSize = Random.Range(1, maxCrowd);
        Vector3 spawnCenter = GetRandomLoc();
        for (int i = 0; i < crowdSize; i++)
        {
            spawnCenter += new Vector3(Random.Range(-crowdSpread, crowdSpread), 0, Random.Range(-crowdSpread, crowdSpread));
            GameObject entity = RequestEntity(0);
            entity.transform.position = spawnCenter;
        }
    }

    protected override List<GameObject> GeneratePoolEntities(GameObject entity, int numOfEntities)
    {
        List<GameObject> entityPool = new List<GameObject>();
        for (int i = 0; i < numOfEntities; i++)
        {
            GameObject go = Instantiate(entity);
            go.transform.parent = this.transform;
            go.GetComponent<Enemy>().player = playerSubject;
            go.SetActive(false);
            entityPool.Add(go);
        }
        return entityPool;
    }
}
