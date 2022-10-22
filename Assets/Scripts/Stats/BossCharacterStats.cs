using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossCharacterStats : EnemyCharacterStats
{
    private Timer timer;
    public static event Action timeStar;
    public static event Action showScore;
   
    private void OnEnable()
    {
        timer = GameObject.FindObjectOfType<Timer>();
        HeroController.weakPoint += Die;
    }

    public override void Die()
    {
        CheckTime();
        showScore?.Invoke();
        Destroy(gameObject);
    }

    public void CheckTime()
    {
        if (timer.time > 60)
        {
            Debug.Log("Buen tiempo, 1 estrella");
            timeStar.Invoke();
        }
    }
}
