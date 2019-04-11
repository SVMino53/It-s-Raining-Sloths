using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public KeyCode RotateLeft;
    public KeyCode RotateRight;
    public float RotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Make it lane based!!!

        if(Input.GetKey(RotateLeft))
        {
            transform.Rotate(0, RotationSpeed, 0);
        }

        if(Input.GetKey(RotateRight))
        {
            transform.Rotate(0, -RotationSpeed, 0);
        }
    }
}
