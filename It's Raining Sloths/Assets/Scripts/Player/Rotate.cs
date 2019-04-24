﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    KeyCode RotateLeft = KeyCode.A;
    [SerializeField]
    KeyCode RotateRight = KeyCode.D;
    [SerializeField]
    public float RotationSpeed = 1.0f;
    [SerializeField]
    int numberOfLanes = 5;
    float rotationAngle;
    bool inRotation = false;
    //easing
    float x = 0.0f;
    bool up = true;

    float curSpeed;
    int curLane;

    // Start is called before the first frame update
    void Start()
    {
        rotationAngle = 360 / numberOfLanes;
        curLane = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Make it lane based!!!
        
        if(Input.GetKeyDown(RotateRight) && !inRotation)
        {
            StartCoroutine(ChangeLane(-RotationSpeed));
            inRotation = true;
            curLane++;
        }

        if(Input.GetKeyDown(RotateLeft) && !inRotation)
        {
            StartCoroutine(ChangeLane(RotationSpeed));
            inRotation = true;
            curLane--;
        }

        if (curLane < 0) curLane = numberOfLanes - 1;
        if (curLane == numberOfLanes) curLane = 0;
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
        inRotation = false;
    }

    public int GetCurLane()
    {
        return curLane;
    }
}