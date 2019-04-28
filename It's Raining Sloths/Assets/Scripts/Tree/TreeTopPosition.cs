using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTopPosition : MonoBehaviour
{
    float treeHeight;
    Vector3 treePosition;
    // Start is called before the first frame update
    void Start()
    {
        treeHeight = GameObject.Find("Trees").GetComponent<InitializeTrees>().GetTreeHeight();
        treePosition = GameObject.Find("Trees").GetComponent<InitializeTrees>().GetTreePosition();
        transform.position = new Vector3(treePosition.x, treeHeight, treePosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
