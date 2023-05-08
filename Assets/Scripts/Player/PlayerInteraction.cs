using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : InteractionBase
{
    public delegate void OnPlayerAttackEventHandler(IDamageable target);
    public static event OnPlayerAttackEventHandler OnPlayerAttack;
   
    protected override void OnTriggerEnterAction(Collider collider)
    {
        Debug.Log("ATTACK");
        OnPlayerAttack?.Invoke(collider.gameObject.GetComponent<IDamageable>());
       
    }

    private void OnTriggerStay(Collider other)
    {
       
    }
}
