using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    private void OnEnable()
    {
        GoldInteraction.OnPickUpParticle += PlayParticle;
        BulletInteraction.OnEnemyDeadParticle += PlayParticle;
    }
    private void PlayParticle(int _index, Vector3 _position)
    {
        ParticleSystem part = transform.GetChild(_index).GetComponent<ParticleSystem>();
        transform.GetChild(_index).position = _position;
        part.Clear();
        part.Play();
    }
    private void OnDisable()
    {
        GoldInteraction.OnPickUpParticle -= PlayParticle;
        BulletInteraction.OnEnemyDeadParticle -= PlayParticle;

    }
}
