using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthBase : MonoBehaviour, IDamageable
{
    protected float health;
    protected abstract void CheckIfDead();

    public float Health
    {
        get { return health; }
        set { health = value; }
    }
    public virtual  Transform GetTransform()
    {
        return transform;
    }

    public virtual void TakeDamage(float damage)
    {
        Health -= damage;
        CheckIfDead();
    }
}
