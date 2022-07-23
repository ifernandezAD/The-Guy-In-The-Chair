using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;
    Vector3 offsett;
    
    void Start()
    {
        target = HeroManager.instance.hero.transform;
        offsett = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offsett;
    }
}
