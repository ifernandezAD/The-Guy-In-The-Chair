using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class DemonCharacterCombat : CharacterCombat
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
            myAnim.SetTrigger("attack1");
            targetStats.TakeDamage(myStats.damage.GetValue());
            attackCooldown = 1f / attackSpeed;
        }
    }
}
