using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CanonTriggerOff : MonoBehaviour
{
    public static event Action heroIsFar;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hero")
        {
            heroIsFar?.Invoke();
        }
    }
}
