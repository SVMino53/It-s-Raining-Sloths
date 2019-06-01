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
    [SerializeField]
    int numOfLanes = 5;

    float rotationAngle = 0;
    int curLane;

    public void ChangeSpeed(float value)
    {
        RotationSpeed = value;
    }

    // Update is called once per frame 
    void Update()
    {
        if (Input.GetKey(RotateLeft))
        {
            transform.Rotate(0, RotationSpeed, 0);
            rotationAngle += RotationSpeed;
        }

        if (Input.GetKey(RotateRight))
        {
            transform.Rotate(0, -RotationSpeed, 0);
            rotationAngle -= RotationSpeed;
        }

        if (rotationAngle > 360) rotationAngle = 0;
        if (rotationAngle < 0) rotationAngle = 360;

        curLane = (int)(rotationAngle/ (360/numOfLanes));
    }
    public int GetCurLane()
    {
        return curLane;
    }

    public void SetButtons(KeyCode left, KeyCode right)
    {
        RotateLeft = left;
        RotateRight = right;
    }

    public KeyCode GetLeft()
    {
        return RotateLeft;
    }

    public KeyCode GetRight()
    {
        return RotateRight;
    }
}


 
