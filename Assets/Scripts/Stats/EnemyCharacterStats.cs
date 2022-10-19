using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyCharacterStats : CharacterStats
{
    public HeroController heroController;
    public Animator myAnim;
    [SerializeField] int deathTime=3;

    private void Start()
    {
        heroController = GameObject.Find("Hero").GetComponent<HeroController>();      
    }

    public override void Die()
    {
        StartCoroutine("AnimatedDeath");
    }

    IEnumerator AnimatedDeath()
    {
        heroController.isWalking = true;
        myAnim.SetTrigger("death");
        yield return new WaitForSeconds(deathTime);
        Destroy(gameObject);
    }

}
