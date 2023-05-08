using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    private EnemyBehaviour enemyBehaviour;
    private EnemyDistance distanceCheck;
    public PatrolState(StateMachine fsm)
    {
        id = StateID.PATROL;
        enemyBehaviour = fsm.GetComponent<EnemyBehaviour>();
        distanceCheck = fsm.GetComponent<EnemyDistance>();
    }
    public override void Act()
    {
        //Patrol in unitsphere 
        enemyBehaviour.SearchObject();
    }

    public override StateID Decide()
    {
        //TODO: check if the enemy can get close to thief return stateID.Chase
        if (distanceCheck.ChaseRange())
        {
            return StateID.CHASE;
        }



        return StateID.NULL;
    }
    public override void OnLeaveState()
    {
        enemyBehaviour.Move(enemyBehaviour.transform.position);
    }
    public override void OnEnterState()
    {
 
    }
}
