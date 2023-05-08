using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "EnemyConfiguration", menuName = "ScriptableObjects/EnemyConfiguration", order = 1)]

public class EnemySO : ScriptableObject
{
    public float health;
    public float movementSpeed;
    public int goldGive;
    public int experienceGive;
    public float updateAIInterval;
    public float enemyDamage;
    public float attackRange;
    public float attackDelay;
    public float angularSpeed;
    public void SetUpAgentFromConfiguration(EnemyConfiguration enemy)
    {
        enemy.gameObject.GetComponent<NavMeshAgent>().angularSpeed = angularSpeed;
        enemy.gameObject.GetComponent<NavMeshAgent>().stoppingDistance = attackRange;
        enemy.gameObject.GetComponent<EnemyHealth>().experienceGive = experienceGive;
        enemy.gameObject.GetComponent<EnemyHealth>().enemyHealth = health;
        //enemy.gameObject.GetComponent<NavMeshAgent>().speed = movementSpeed;

        //enemy.gameObject.GetComponent<EnemyHealth>().goldGive = goldGive;
        //enemy.gameObject.GetComponent<Enemy>().enemyDamage = enemyDamage;

    }
}
