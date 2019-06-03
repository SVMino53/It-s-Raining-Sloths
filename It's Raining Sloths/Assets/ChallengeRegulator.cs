using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeRegulator : MonoBehaviour
{
    GameObject player;
    float curPlayerPos;
    float treeHeight;

    [SerializeField]
    float multiplyerRocks = 0.66f;
    [SerializeField]
    float multiplyerSloths = 1.5f;
    [SerializeField]
    float stepPerc = 25;

    float nextHeight;
    float partHeight;
    float prHeight;
    GameObject rockSpawner;
    // Start is called before the first frame update
    void Start()
    {
        treeHeight = GameObject.Find("Trees").GetComponent<InitializeTrees>().GetTreeHeight();
        rockSpawner = GameObject.Find("RockSp");
        partHeight = treeHeight * (stepPerc * 0.01f);
        nextHeight = partHeight;
        player = GameObject.Find("Player");
        curPlayerPos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        curPlayerPos = player.GetComponent<GeneralMovement>().GetCurPosY();
        if(curPlayerPos >= nextHeight)
        {
            nextHeight += partHeight;
            GetComponent<SpawnSlothBaby>().ChangeSpawnRate(multiplyerSloths);
            if(rockSpawner)
                rockSpawner.GetComponent<SpawnSlothBaby>().ChangeSpawnRate(multiplyerRocks);
        }
    }
}
