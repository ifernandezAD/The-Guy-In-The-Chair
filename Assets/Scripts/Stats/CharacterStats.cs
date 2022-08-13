using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    //Stats
    public float maxHealth;
    public float currentHealth;
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
        

        healthBarSprite.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        print("You are dead");       
    }

}
