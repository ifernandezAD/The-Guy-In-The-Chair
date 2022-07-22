using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterStats : CharacterStats
{
    public override void Die()
    {
        Destroy(gameObject);
    }
}
