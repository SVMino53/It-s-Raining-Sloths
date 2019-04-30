using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InitializeTrees : MonoBehaviour
{
    GameObject[] treeParts;
    [SerializeField]
    float treeHeight = 500.0f;
    [SerializeField]
    float treePartHeight = 10.0f;
    [SerializeField]
    string TreeTag = "Tree";

    // Start is called before the first frame update
    void Start()
    {
        treeParts = GameObject.FindGameObjectsWithTag(TreeTag);
        if(treeParts[0] != null)
            treePartHeight = treeParts[0].transform.lossyScale.y;

        if(treeParts.Length == 2)
        {
            treeParts[0].transform.position = new Vector3(transform.position.x, transform.position.y + treePartHeight*0.5f, transform.position.z);
            treeParts[1].transform.position = new Vector3(treeParts[0].transform.position.x, treeParts[0].transform.position.y + treePartHeight, treeParts[0].transform.position.z);
        }

        if(treeHeight % treePartHeight != 0 && treePartHeight != 0)
        {
            treeHeight = treePartHeight * ((int)(treeHeight / treePartHeight)-1);
        }
    }

    public float GetTreeHeight()
    {
        return treeHeight;
    }

    public Vector3 GetTreePosition()
    {
        return treeParts[0].transform.position;
    }
}
