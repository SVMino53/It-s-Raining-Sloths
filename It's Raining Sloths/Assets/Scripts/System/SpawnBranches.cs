using System.Collections;
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
    float MinHeight = 20.0f;
    [SerializeField]
    float MaxHeight = 0;
    [SerializeField]
    [Range(2, 100)]
    int Lanes = 5;
    [SerializeField]
    float LaneOffset = 0.0f;
    [SerializeField]
    string TreesName;

    float BranchHeight;

    void SpawnBranch(int PrevLane)
    {
        int Lane;

        do
        {
            Lane = Mathf.FloorToInt(Random.Range(0.0f, Lanes - 0.00001f));
        } while (Lane == PrevLane);

        Quaternion BranchRotation = Quaternion.Euler(new Vector3(0.0f, 360.0f / Lanes * Lane + LaneOffset, 0.0f));

        Instantiate<Object>(BranchObj, new Vector3(0.0f, BranchHeight, 0.0f), BranchRotation);
        
        BranchHeight += Random.Range(MinDistance, MaxDistance);

        if(BranchHeight <= MaxHeight)
        {
            SpawnBranch(Lane);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        BranchHeight = MinHeight;
        MaxHeight = GameObject.Find(TreesName).GetComponent<InitializeTrees>().GetTreeHeight();
        SpawnBranch(-1);
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
