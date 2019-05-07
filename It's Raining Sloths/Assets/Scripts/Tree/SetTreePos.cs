using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTreePos : MonoBehaviour
{
    [SerializeField]
    string TreesName;

    float treeHeight;
    
    // Start is called before the first frame update
    void Start()
    {
        treeHeight = GameObject.Find(TreesName).GetComponent<InitializeTrees>().GetTreeHeight();
        transform.position = new Vector3(transform.position.x, treeHeight, transform.position.z);
    }
}
