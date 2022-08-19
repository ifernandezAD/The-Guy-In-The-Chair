using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HeroCharacterStats : CharacterStats
{
    public static event Action pederastianStar;

    public override void Die()
    {
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Pederastian")
        {
            pederastianStar?.Invoke();
            currentHealth += 40;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Bullet")
        {
            currentHealth -= 5;
            Destroy(other.gameObject);

        }
    }
}
