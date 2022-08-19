using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossCharacterStats : EnemyCharacterStats
{
    private Timer timer;

    private void OnEnable()
    {
        timer = GameObject.FindObjectOfType<Timer>();
        HeroController.weakPoint += DestroyBoss;
    }

    public void DestroyBoss()
    {
       
        Destroy(this.gameObject);
    }

    public override void Die()
    {
        CheckTime();
        Destroy(gameObject);
    }

    public void CheckTime()
    {

    }
}
