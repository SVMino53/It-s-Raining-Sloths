using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeTrees : MonoBehaviour
{
    GameObject[] treeParts;
    [SerializeField]
    float treeHeight;
    [SerializeField]
    float treePartHeight;
    // Start is called before the first frame update
    void Start()
    {
        treeParts = GameObject.FindGameObjectsWithTag("Tree");
        if(treeParts[0]!=null)
            treePartHeight = treeParts[0].transform.lossyScale.y;

        if(treeParts.Length == 2)
        {
            treeParts[0].transform.position = new Vector3(transform.position.x, -treePartHeight, transform.position.z);
            treeParts[1].transform.position = new Vector3(transform.position.x, treePartHeight, transform.position.z);
        }
    }

    public float GetTreeHeight()
    {
        return treeHeight;
    }
}
