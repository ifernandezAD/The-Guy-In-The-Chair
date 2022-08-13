using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonEnemyBehaviour : MonoBehaviour
{
    private bool isActive;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float cooldown;
   
    private void OnEnable()
    {        
        CanonTriggerOn.heroIsNear += ShootHero;
        CanonTriggerOff.heroIsFar += NotShootHero;
    }

    public void ShootHero()
    {
        isActive = true;
        StartCoroutine("Shooting");
    }

    public void NotShootHero()
    {
        isActive = false;
    }

    IEnumerator Shooting()
    {
        while (isActive)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

            yield return new WaitForSeconds(cooldown);
        }                
    }
}
