using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharacterStats : CharacterStats
{
    public override void Die()
    {
        this.gameObject.SetActive(false);
    }

}
