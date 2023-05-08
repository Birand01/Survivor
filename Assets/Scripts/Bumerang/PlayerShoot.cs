using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerShoot : ShootBase
{
  
    private void OnEnable()
    {
        PlayerInteraction.OnPlayerAttack += Shoot;
    }

  
    private void OnDisable()
    {
        PlayerInteraction.OnPlayerAttack -= Shoot;

    }
}
