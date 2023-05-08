using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private EnemyBehaviour enemyBehaviour;
    private EnemyDistance distanceCheck;
    private EnemyAnimationEvents enemyAnimationEvents;
    public AttackState(StateMachine fsm)
    {
        id = StateID.ATTACK;
        enemyBehaviour = fsm.GetComponent<EnemyBehaviour>();
        distanceCheck = fsm.GetComponent<EnemyDistance>();
        enemyAnimationEvents = fsm.GetComponent<EnemyAnimationEvents>();
    }
    public override void Act()
    {
        Debug.Log("Attack");
        enemyBehaviour.LookAtTarget(enemyBehaviour.objectToAttack);
        enemyBehaviour.Attack();
    }

    public override StateID Decide()
    {
        if (enemyBehaviour.objectToAttack == null || distanceCheck.ChaseRange())
        {
            return StateID.CHASE;
        }
        else if (enemyBehaviour.objectToAttack.GetComponent<PlayerHealth>().Health <= 0)
        {
            return StateID.IDLE;
        }


        return StateID.NULL;
    }

    public override void OnEnterState()
    {
        enemyAnimationEvents.AttackAnimationEvent(true);

    }

    public override void OnLeaveState()
    {
        enemyAnimationEvents.AttackAnimationEvent(false);
    }

}
