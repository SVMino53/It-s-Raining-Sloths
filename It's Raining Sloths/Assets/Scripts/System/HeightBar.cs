using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightBar : MonoBehaviour
{
    float treeHeight;
    float curPos;
    GameObject player = null;
    [SerializeField]
    float treeTopLength = 20;
    [SerializeField]
    string treesName = "Trees";
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        treeHeight = GameObject.Find(treesName).GetComponent<InitializeTrees>().GetTreeHeight();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            curPos = player.GetComponent<GeneralMovement>().GetCurPosY();
        GlobalVars.Progress = curPos/(treeHeight - treeTopLength);
        GetComponent<Slider>().value = GlobalVars.Progress;
    }
}
