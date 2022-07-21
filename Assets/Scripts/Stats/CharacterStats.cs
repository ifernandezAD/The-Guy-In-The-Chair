using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    //Stats
    public float maxHealth = 100;
    public float currentHealth { get; private set; }
    public Stat damage;
    public Stat armor;

    [SerializeField] private Image healthBarSprite;
    

    private void Awake()

    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue); //Prevents negative damage that heal the character

        currentHealth -= damage;
        print(transform.name + " takes " + damage + " damage.");

        healthBarSprite.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        print("You are dead");
        //This method is meant to be overwritten
    }
}
