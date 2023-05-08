using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    private EnemyBehaviour enemybehaviour;
    private EnemyDistance distanceCheck;
    private EnemyAnimationEvents enemyAnimationEvents;
    public ChaseState(StateMachine fsm)
    {
        id = StateID.CHASE;
        enemybehaviour = fsm.GetComponent<EnemyBehaviour>();
        distanceCheck = fsm.GetComponent<EnemyDistance>();
        enemyAnimationEvents = fsm.GetComponent<EnemyAnimationEvents>();
    }
    public override void Act()
    {
        if (enemybehaviour.objectToAttack == null) return;
        enemybehaviour.Chase();
    }

    public override StateID Decide()
    {
        if (enemybehaviour.objectToAttack != null && distanceCheck.AttackRange())
        {
            return StateID.ATTACK;
        }
        //else if (enemybehaviour.objectToAttack != null && distanceCheck.PatrolRange())
        //{
        //    return StateID.PATROL;
        //}

        return StateID.NULL;
    }
    public override void OnEnterState()
    {
        enemyAnimationEvents.ChaseAnimationEvent(true);
    }
    public override void OnLeaveState()
    {
        enemyAnimationEvents.ChaseAnimationEvent(false);
    }
}
