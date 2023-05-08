using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : HealthBase
{
    public delegate void OnEnemyDeadAnimationHandler(GameObject gameObject, string name);
    public static event OnEnemyDeadAnimationHandler OnEnemyDeadAnimation;
    public delegate void OnEnemyDeadCounterHandler(int cointCount);
    public static event OnEnemyDeadCounterHandler OnDeadCounter;
    public delegate void OnDecreaseEnemyAmountHandler();
    public static event OnDecreaseEnemyAmountHandler OnDecreaseEnemyAmount;
    internal float enemyHealth;
    internal int experienceGive;
 
    protected override void CheckIfDead()
    {
        if(Health<=0)
        {
            StartCoroutine(DeadCoroutine());
        }
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        Health = Mathf.Clamp(Health, 0, enemyHealth);

    }

    private IEnumerator DeadCoroutine()
    {
        OnDecreaseEnemyAmount?.Invoke();
        OnDeadCounter?.Invoke(experienceGive);
        //this.gameObject.GetComponent<NavMeshAgent>().enabled = false;
        //this.gameObject.GetComponent<Collider>().enabled = false;
        OnEnemyDeadAnimation?.Invoke(this.gameObject, "Dead");
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}
