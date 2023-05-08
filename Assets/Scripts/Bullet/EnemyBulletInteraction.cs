using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletInteraction : InteractionBase
{

    public delegate void OnBulletDisableEventHandler();
    public static event OnBulletDisableEventHandler OnBulletDisable;
    [SerializeField] internal float damage;
    protected override void OnTriggerEnterAction(Collider collider)
    {
        Debug.Log("Player is hit");
        OnBulletDisable?.Invoke();
        IDamageable damageable = collider.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }
    }

}
