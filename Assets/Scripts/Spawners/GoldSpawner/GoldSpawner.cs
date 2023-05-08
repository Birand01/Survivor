using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSpawner : SpawnBase
{
    [SerializeField] private float xRange, zRange;

    protected override void Awake()
    {
        base.Awake();
        SpawnAction();
    }

    public override void SpawnAction()
    {       
        GameObject gold = Instantiate(objectPrefab);
        gold.transform.parent = transform;
        gold.transform.position = new Vector3(Random.Range(-xRange, xRange), 1, Random.Range(-zRange, zRange));
      
    }
   

}
