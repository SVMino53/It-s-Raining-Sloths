﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    KeyCode RotateLeft;
    [SerializeField]
    KeyCode RotateRight;
    [SerializeField]
    float RotationSpeed;
    [SerializeField]
    int numberOfLanes;
    float rotationAngle;
    
    //easing
    float x = 0.0f;
    bool up = true;

    public float curSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rotationAngle = 360 / numberOfLanes;
    }

    // Update is called once per frame
    void Update()
    {
        // Make it lane based!!!
        
        if(Input.GetKeyDown(RotateLeft))
        {
            StartCoroutine(ChangeLane(RotationSpeed));
        }

        if(Input.GetKeyDown(RotateRight))
        {
            StartCoroutine(ChangeLane(-RotationSpeed));
        }
    }

    IEnumerator ChangeLane(float speed)
    {
        float curAngel = 0;
        while(curAngel < rotationAngle)
        {
            transform.Rotate(0, speed, 0);
            curAngel += Mathf.Abs(speed);
            yield return null;
        }
    }

    /*float GetCurSpeed()
    {
        x += 0.01f;
        if (x >= 2*Mathf.PI) x = 0;
        //if (Mathf.Sin(x) <= RotationSpeed/2)
        return Mathf.Sin(x/2);
    }*/
}
