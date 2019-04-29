using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlothBaby : MonoBehaviour
{
    [SerializeField]
    GameObject BabySlothObj = null;
    [SerializeField]
    int numberOfLanes = 5;
    [SerializeField]
    float DistanceFromPlayer = 20;
    [SerializeField]
    string TreesName = "Trees";
    [SerializeField]
    string PlayerTag = "Player";

    [SerializeField]
    float spawnRate = 1;

    float startTime;
    
    int spawnLane;
    int slothLane;
    float testRotation;

    GameObject sloth;
    GameObject babySloth;
    [SerializeField]
    float treeHeight;
    // Start is called before the first frame update 
    void Start()
    {
        treeHeight = GameObject.Find(TreesName).GetComponent<InitializeTrees>().GetTreeHeight();
        sloth = GameObject.FindGameObjectWithTag(PlayerTag);
        slothLane = sloth.GetComponent<Rotate>().GetCurLane();
        startTime = Time.time;
    }

    void SpawnSloth(int lane)
    {
        Quaternion SlothRotation = Quaternion.Euler(new Vector3(0, 360.0f / numberOfLanes * (lane), 0));
        testRotation = 360.0f / numberOfLanes * (lane);
        babySloth = Instantiate<GameObject>(BabySlothObj, new Vector3(2.0f, sloth.transform.position.y + DistanceFromPlayer, 0.0f), SlothRotation);
        babySloth.transform.RotateAround(new Vector3(0, transform.position.y, 0), new Vector3(0,1,0), -testRotation+90);
    }

    // Update is called once per frame 
    void Update()
    {
        if (Time.time - startTime >= spawnRate)
        {
            if (sloth != null)
            {
                slothLane = sloth.GetComponent<Rotate>().GetCurLane();
                spawnLane = slothLane + Random.Range(-1, 2);

                if (spawnLane < 0) spawnLane = numberOfLanes - 1;
                if (spawnLane == numberOfLanes) spawnLane = 0;

                if (sloth.transform.position.y > treeHeight - DistanceFromPlayer)
                    Destroy(this);

                SpawnSloth(spawnLane);

                startTime = Time.time;
            }

            //delete / get back to pool if sloth falls 
        }
    }
}