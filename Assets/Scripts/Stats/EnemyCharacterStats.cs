using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterStats : CharacterStats
{
    public HeroController heroController;

    private void Start()
    {
        heroController = GameObject.Find("Hero").GetComponent<HeroController>();      
    }

    public override void Die()
    {
        heroController.isWalking = true;
        Destroy(gameObject);    
    }
}
