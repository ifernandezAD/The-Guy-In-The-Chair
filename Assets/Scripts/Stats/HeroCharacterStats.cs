using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharacterStats : CharacterStats
{
    public override void Die()
    {
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Pederastian")
        {
            currentHealth += 40;
            Destroy(other.gameObject);
        }
    }
}
