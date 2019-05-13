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
        mainTreeHeight = GameObject.Find("TreeTrunks").GetComponent<InitializeTrees>().GetTreeHeight();
        transform.localScale = new Vector3(transform.localScale.x, mainTreeHeight, transform.localScale.z);
        transform.position = new Vector3(transform.position.x, mainTreeHeight*0.5f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

        //mainTreeHeight = GameObject.Find(TreesName).GetComponent<InitializeTrees>().GetTreeHeight();