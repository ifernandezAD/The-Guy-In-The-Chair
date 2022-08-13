using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CanonTriggerOn : MonoBehaviour
{
    public static event Action heroIsNear;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hero")
        {
            heroIsNear?.Invoke();
        }
    }
}
   
