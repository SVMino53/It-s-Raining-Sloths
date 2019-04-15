using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Analog : MonoBehaviour
{
    [SerializeField]
    KeyCode RotateLeft = KeyCode.A;
    [SerializeField]
    KeyCode RotateRight = KeyCode.D;
    [SerializeField]
    public float RotationSpeed = 1.0f;

    // Update is called once per frame 
    void Update()
    {
        // Make it lane based!!! 

        if (Input.GetKey(RotateLeft))
        {
            transform.Rotate(0, RotationSpeed, 0);
        }

        if (Input.GetKey(RotateRight))
        {
            transform.Rotate(0, -RotationSpeed, 0);
        }
    }
}