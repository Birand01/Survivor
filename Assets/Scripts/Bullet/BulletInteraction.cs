using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInteraction : InteractionBase
{
    public delegate void OnBulletDisableEventHandler();
    public static event OnBulletDisableEventHandler OnBulletDisable;
    public delegate void OnGameSuccessSoundHandler(string name, bool state);
    public static event OnGameSuccessSoundHandler OnEnemyDeadSound;
    public delegate void OnEnemyDeadParticleHandler(int index, Vector3 position);
    public static event OnEnemyDeadParticleHandler OnEnemyDeadParticle;
    [SerializeField] internal float damage;
    protected override void OnTriggerEnterAction(Collider collider)
    {
        OnEnemyDeadParticle?.Invoke(0,this.transform.position);
        OnEnemyDeadSound?.Invoke("EnemyDeadSound", true);
        OnBulletDisable?.Invoke();
        IDamageable damageable = collider.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }
    }
}
