using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationManager : MonoBehaviour
{

    private void OnEnable()
    {
        EnemyHealth.OnEnemyDeadAnimation += AnimationTrigger;
        EnemyAnimationEvents.OnPoliceWinAnimation += AnimationTrigger;
        EnemyAnimationEvents.OnPoliceAttackAnimation += AnimationState;
        EnemyAnimationEvents.OnPoliceChaseAnimation += AnimationState;
    }

    private void AnimationState(GameObject gameObject, string name, bool state)
    {
        gameObject.GetComponent<Animator>().SetBool(name, state);
    }
    private void AnimationTrigger(GameObject gameObject, string name)
    {
        gameObject.GetComponent<Animator>().SetTrigger(name);
    }
    private void OnDisable()
    {
        EnemyAnimationEvents.OnPoliceWinAnimation -= AnimationTrigger;
        EnemyAnimationEvents.OnPoliceAttackAnimation -= AnimationState;
        EnemyAnimationEvents.OnPoliceChaseAnimation -= AnimationState;
        EnemyHealth.OnEnemyDeadAnimation -= AnimationTrigger;

    }
}
