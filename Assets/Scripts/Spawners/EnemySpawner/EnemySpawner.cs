using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class EnemySpawner : SpawnBase
{
    [SerializeField] private Transform prefabParent;
   
    private void OnEnable()
    {
        EnemyHealth.OnDecreaseEnemyAmount += DecreaseEnemyNumber;
    }

    public override void SpawnAction()
    {
        float height = Camera.main.orthographicSize+ Random.Range(-100, 100);
        float width = height * Camera.main.aspect+Random.Range(-100,100);
        GameObject enemy = Instantiate(objectPrefab);
        enemy.transform.SetParent(prefabParent);
        enemy.transform.position = new Vector3(Camera.main.transform.position.x+Random.Range(-width,width),
            enemy.transform.position.y+1f, Camera.main.transform.position.z + height + Random.Range(-70, 70));
        enemy.transform.rotation = Quaternion.identity;

    }


    private void DecreaseEnemyNumber()
    {
        spawnedObjectNumber --;
    }

    private void OnDisable()
    {
        EnemyHealth.OnDecreaseEnemyAmount -= DecreaseEnemyNumber;
    }


}
