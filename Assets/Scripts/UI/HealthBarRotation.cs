using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarRotation : MonoBehaviour
{
    public GameObject hero;

    private void Update()
    {
        transform.position = new Vector3 (hero.transform.position.x - 1, hero.transform.position.y, hero.transform.position.z);
    }

    private void LateUpdate()
    {
       // transform.LookAt(transform.position + Camera.main.transform.forward);
    }
}
