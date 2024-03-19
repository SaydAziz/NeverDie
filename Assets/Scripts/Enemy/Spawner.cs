using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject[] entityPrefabs;
    [SerializeField] protected List<GameObject> entityPool;
    [SerializeField] protected int entityAmount;

    [SerializeField] protected Collider spawnPerimeter;

    [SerializeField] protected float spawnInterval;

    protected bool canSpawn;

    public abstract void SpawnEntity();
    protected abstract Vector3 GetRandomLoc();

    protected virtual List<GameObject> GeneratePoolEntities(GameObject entity, int numOfEntities)
    {
        Debug.Log("Generating Pool");
        List<GameObject> entityPool = new List<GameObject>();
        for (int i = 0; i < numOfEntities; i++)
        {
            GameObject go = Instantiate(entity);
            go.transform.parent = this.transform;
            go.SetActive(false);
            entityPool.Add(go);
        }
        return entityPool;
    }

    protected GameObject RequestEntity(int entityID) 
    {
        foreach (GameObject go in entityPool)
        {
            if (go.activeInHierarchy == false)
            {
                go.SetActive(true);
                return go;
            }
        }

        GameObject newEntity = Instantiate(entityPrefabs[entityID]);
        newEntity.transform.parent = this.transform;
        entityPool.Add(newEntity);
        
        return newEntity;
    }

}
