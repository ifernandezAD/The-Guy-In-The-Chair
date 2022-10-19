using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FishCharacterCombat : CharacterCombat
{
    CharacterStats myStats;
    public Animator myAnim;
    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    public override void Attack(CharacterStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            RandomAttack();
            targetStats.TakeDamage(myStats.damage.GetValue());
            attackCooldown = 1f / attackSpeed;
        }
    }

    void RandomAttack()
    {
        int attack = Random.Range(0, 3);

        if (attack == 0)
        {
            myAnim.SetTrigger("attack1");
        }
        if (attack == 1)
        {
            myAnim.SetTrigger("attack2");
        }
        if (attack == 2)
        {
            myAnim.SetTrigger("attack3");
        }
    }
}
