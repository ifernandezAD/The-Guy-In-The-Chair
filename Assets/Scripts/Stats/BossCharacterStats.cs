using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCharacterStats : EnemyCharacterStats
{

    private void OnEnable()
    {
        HeroController.weakPoint += DestroyBoss;
    }

    public void DestroyBoss()
    {
        Destroy(this.gameObject);
    }

    public override void Die()
    {
        Destroy(gameObject);
    }


}
