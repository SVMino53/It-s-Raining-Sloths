using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTopPosition : MonoBehaviour
{
    [SerializeField]
    float treeHeight;
    [SerializeField]
    Vector3 treePosition;
    [SerializeField]
    string TreesName = "Trees";

    // Start is called before the first frame update
    void Start()
    {
        treeHeight = GameObject.Find(TreesName).GetComponent<InitializeTrees>().GetTreeHeight();
        treePosition = GameObject.Find(TreesName).GetComponent<InitializeTrees>().GetTreePosition();
        transform.position = new Vector3(treePosition.x, treeHeight, treePosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
