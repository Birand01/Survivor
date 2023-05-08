using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnBase : MonoBehaviour
{
    [SerializeField] protected GameObject objectPrefab;
    [SerializeField] protected float spawnDelay;
    [SerializeField] protected int spawnedObjectNumber, totalNumberObjectToSpawn;

    protected virtual void Awake()
    {
        spawnedObjectNumber = 0;
    }
    protected virtual void Start()
    {
    }
    private void Update()
    {
        StartCoroutine(SpawnObject(spawnDelay));

    }
    protected virtual IEnumerator SpawnObject(float delay)
    {
        yield return new WaitForSeconds(delay);
        while (spawnedObjectNumber < totalNumberObjectToSpawn)
        {
            spawnedObjectNumber++;
            SpawnAction();
            yield return new WaitForSeconds(delay);
            //if (spawnedObjectNumber == totalNumberObjectToSpawn)
            //{
            //    StopCoroutine(SpawnPolice(delay));
            //}
        }

    }



    public virtual void SpawnAction() { }
}
