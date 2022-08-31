using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float rotateSpeedX;
    public float rotateSpeedY;
    public float rotateSpeedZ;

    void Update()
    {
        transform.Rotate(new Vector3 (rotateSpeedX, rotateSpeedY, rotateSpeedZ));
    }
}
