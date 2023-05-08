using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{


    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeadEvent += DisableGameobject;
    }
    private void DisableGameobject()
    {
        this.gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeadEvent -= DisableGameobject;

    }
}
