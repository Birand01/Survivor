using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private EnemyAnimationEvents enemyAnimationEvents;
    private EnemyBehaviour enemyBehaviour;
    public IdleState(StateMachine fsm)
    {
        id = StateID.IDLE;
        enemyAnimationEvents = fsm.GetComponent<EnemyAnimationEvents>();
        enemyBehaviour = fsm.GetComponent<EnemyBehaviour>();
    }
    public override void Act()
    {
        Debug.Log("WinZone");
    }

    public override StateID Decide()
    {
        return StateID.NULL;
    }

    public override void OnEnterState()
    {

        enemyAnimationEvents.WinAnimation();
    }
}
