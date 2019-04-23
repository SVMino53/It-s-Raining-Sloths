using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growing : MonoBehaviour
{
    [SerializeField]
    float visibleHeight = 20;
    [SerializeField]
    float maxHeight = 400;

    float treeTopY;
    float treeHeight;
    float playerCurPosY;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        treeTopY = transform.lossyScale.y;
        treeHeight = treeTopY;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player!=null)
            playerCurPosY = player.GetComponent<Move>().getCurPosY();

        if(playerCurPosY >= treeTopY - visibleHeight && treeTopY<maxHeight)
        {
            RepositionTree();
            treeTopY += treeHeight;
        }
    }

    private void RepositionTree()
    {
        Vector3 treeOffset = new Vector3(0, treeHeight, 0);
        transform.position = transform.position + treeOffset;
    }

}
