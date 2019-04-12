using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBranches : MonoBehaviour
{
    public Object BranchObj;
    public float MinDistance;
    public float MaxDistance;
    public float MinHight;
    public float MaxHight;
    public int Lanes = 2;
    public float LaneOffset = 0.0f;

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
        if(Lanes < 2)
        {
            Lanes = 2;
        }

        BranchHight = MinHight;
        SpawnBranch(-1);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
