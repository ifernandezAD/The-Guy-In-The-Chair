using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossBattleTrigger : MonoBehaviour
{
    public static event Action bossBattleBegins;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hero")
        {
            bossBattleBegins?.Invoke();
        }
    }
}
