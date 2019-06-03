using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTopPosition : MonoBehaviour
{
    [SerializeField]
    string TreesName;

    float treeHeight;
    Vector3 treePosition;

    // Start is called before the first frame update
    void Start()
    {
        treeHeight = GameObject.Find(TreesName).GetComponent<InitializeTrees>().GetTreeHeight();
        treePosition = transform.position;
        transform.position = new Vector3(treePosition.x, treeHeight*1.01f, treePosition.z);
    }
}
