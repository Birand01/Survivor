using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : BehaviourBase
{
    [SerializeField]
    protected float chaseSpeed;
    private EnemyShoot enemyShoot;


    protected override void Awake()
    {

        enemyShoot = GetComponentInChildren<EnemyShoot>();
        base.Awake();

    }
    
    protected override void Start()
    {
        objectToAttack = GameObject.FindGameObjectWithTag("Player").transform;

    }
    public override void Move(Vector3 destination)
    {
        if (agent == null) return;
        agent.SetDestination(destination);
    }
    public override void Attack()
    {
        if (agent != null)
        {
            agent.isStopped = true;
            enemyShoot.Shoot(objectToAttack.gameObject.GetComponent<IDamageable>());
        }


    }


    


    internal void Chase()
    {
        if (objectToAttack == null)
            return;
        agent.isStopped = false;
        agent.speed = chaseSpeed;
        agent.SetDestination(objectToAttack.position);

    }


}
