using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossCharacterStats : EnemyCharacterStats
{
    private Timer timer;
    public static event Action timeStar;

    private void OnEnable()
    {
        timer = GameObject.FindObjectOfType<Timer>();
        HeroController.weakPoint += Die;
    }

    public override void Die()
    {
        CheckTime();
        Destroy(gameObject);
    }

    public void CheckTime()
    {
        if (timer.time > 60)
        {
            Debug.Log("Tiempo de puta madre, 1 estrella");
            timeStar.Invoke();
        }
    }
}
