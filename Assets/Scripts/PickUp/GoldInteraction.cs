using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GoldInteraction : InteractionBase
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private int goldValue;
    public delegate void OnPlayerGoldCollectHandler(int cointCount);
    public static event OnPlayerGoldCollectHandler OnGoldCollected;
    public delegate void OnGoldSoundHandler(string name, bool state);
    public static event OnGoldSoundHandler OnGoldSound;
    public delegate void OnPickUpParticleHandler(int index, Vector3 position);
    public static event OnPickUpParticleHandler OnPickUpParticle;
    private void Update()
    {
        this.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
        //transform.DOShakePosition(.5f, strength: new Vector3(0, 2, 0), vibrato: 1, randomness: 1);
    }



    protected override void OnTriggerEnterAction(Collider collider)
    {
        OnPickUpParticle?.Invoke(1, this.transform.position);
        OnGoldSound?.Invoke("GoldSound", true);
        OnGoldCollected?.Invoke(goldValue);
        this.gameObject.SetActive(false);
    }
}
