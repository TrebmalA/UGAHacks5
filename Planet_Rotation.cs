using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_Rotation : MonoBehaviour
{
    public float rotationSpeed;
    public Vector3 rotAxis;
    void Update()
    {
        transform.Rotate(rotAxis * (rotationSpeed * Time.deltaTime));
    }
}
