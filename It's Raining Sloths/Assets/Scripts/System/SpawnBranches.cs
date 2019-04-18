﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBranches : MonoBehaviour
{
    [SerializeField]
    Object BranchObj;
    [SerializeField]
    [Range(0.1f, 100.0f)]
    float MinDistance = 5.0f;
    [SerializeField]
    [Range(0.2f, 100.0f)]
    float MaxDistance = 15.0f;
    [SerializeField]
    float MinHight = 20.0f;
    [SerializeField]
    float MaxHight = 450.0f;
    [SerializeField]
    [Range(2, 100)]
    int Lanes = 5;
    [SerializeField]
    float LaneOffset = 0.0f;

    float BranchHight;

    void SpawnBranch(int PrevLane)
    {
        int Lane;

        do
        {
            Lane = Mathf.FloorToInt(Random.Range(0.0f, Lanes - 0.00001f));
        } while (Lane == PrevLane);

        Quaternion BranchRotation = Quaternion.Euler(new Vector3(0.0f, 360.0f / Lanes * Lane + LaneOffset, 0.0f));

        Instantiate<Object>(BranchObj, new Vector3(0.0f, BranchHight, 0.0f), BranchRotation);

        BranchHight += Random.Range(MinDistance, MaxDistance);

        if(BranchHight <= MaxHight)
        {
            SpawnBranch(Lane);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        BranchHight = MinHight;
        SpawnBranch(-1);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
