using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBranches : MonoBehaviour
{
    //[SerializeField]
    //GameObject BranchObj;
    [SerializeField]
    [Range(0.1f, 100.0f)]
    float MinDistance = 5.0f;
    [SerializeField]
    [Range(0.2f, 100.0f)]
    float MaxDistance = 15.0f;
    [SerializeField]
    float MinHeight = 20.0f;
    [SerializeField]
    float MaxHeight = 10.0f;
    [SerializeField]
    Vector3 PositionOffset = new Vector3(0.0f, 0.0f, 0.0f);
    [SerializeField]
    [Range(2, 100)]
    int Lanes = 5;
    [SerializeField]
    float LaneOffset = 0.0f;
    [SerializeField]
    string TreesName = "Trees";
    [SerializeField]
    GameObject[] branchPrefabs;

    float BranchHeight;
    int branchTypeNum = 0;

    void SpawnBranch(int PrevLane)
    {
        int Lane;

        do
        {
            Lane = Mathf.FloorToInt(Random.Range(0.0f, Lanes - 0.00001f));
        } while (Lane == PrevLane);

        Quaternion BranchRotation = Quaternion.Euler(new Vector3(0.0f, 360.0f / Lanes * Lane + LaneOffset, 0.0f));

        if (branchPrefabs.Length > 0)
            branchTypeNum = Random.Range(0, branchPrefabs.Length);
        else return;

        GameObject NewBranch = Instantiate<GameObject>(branchPrefabs[branchTypeNum], new Vector3(transform.position.x, BranchHeight, transform.position.z), BranchRotation);
        
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
}
