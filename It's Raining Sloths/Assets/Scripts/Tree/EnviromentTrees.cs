using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentTrees : MonoBehaviour
{
    [SerializeField]
    string TreesName =  "Trees";
    
    float mainTreeHeight;

    // Start is called before the first frame update
    void Start()
    {

        mainTreeHeight = GameObject.Find(TreesName).GetComponent<InitializeTrees>().GetTreeHeight();
        transform.localScale = new Vector3(transform.localScale.x, mainTreeHeight*2, transform.localScale.z);
        //transform.position = new Vector3(transform.position.x, mainTreeHeight, transform.position.z);
    }
}
