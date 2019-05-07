﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMovement : MonoBehaviour
{
    float speed = 20.05f;
    [SerializeField]
    string TreesName = "Trees";

    float initialXpos;
    float initialZpos;
    float treeHeight;
    [SerializeField]
    public bool moving = true;
    [SerializeField]
    float BounceDownHeight = 10f;
    [SerializeField]
    float StannedLength = 0.3f;

    /*...........*/
   float minHeight;

    public void SetSpeed(float value)
    {
        speed = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        initialXpos = transform.position.x;
        initialZpos = transform.position.z;
        treeHeight = GameObject.Find(TreesName).GetComponent<InitializeTrees>().GetTreeHeight();
    }


    public void Move()
    {
        transform.position = new Vector3(initialXpos, transform.position.y, initialZpos);

        if (GetComponent<CollisionCheck>().Colliding() && moving)
        {
            GetComponent<BounceDown>().Bounce(speed);
            GetComponent<CollisionCheck>().SetColliding(false);
        }
        if (moving)
        {
            if (transform.position.y + speed <= treeHeight && transform.position.y + speed >= initialXpos)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
            }
        }
    }

    public float GetCurPosY()
    {
        return transform.position.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Rock"))
        {
            GetComponent<BounceDown>().Bounce(speed, false);
            other.gameObject.SetActive(false);
        }
    }
}