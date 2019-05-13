using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlothBaby : MonoBehaviour
{
    [SerializeField]
    GameObject[] Objs;
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
    GameObject obj;
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

    void SpawnObject(int lane)
    {
        Quaternion ObjRotation = Quaternion.Euler(new Vector3(0, 360.0f / numberOfLanes * (lane), 0));
        testRotation = 360.0f / numberOfLanes * (lane);

        int rnd  = Random.Range(0, Objs.Length);
        
        obj = Instantiate<GameObject>(Objs[rnd], new Vector3(2.0f, GameObject.Find(TreesName).GetComponent<InitializeTrees>().GetTreeHeight() /*sloth.transform.position.y + DistanceFromPlayer*/, 0.0f), ObjRotation);
        obj.transform.RotateAround(new Vector3(0, transform.position.y, 0), new Vector3(0,1,0), -testRotation+90);
    }

    // Update is called once per frame 
    void Update()
    {
        if (Time.time - startTime >= spawnRate)
        {
            if (sloth != null)
            {
                if (sloth.GetComponent<Rotate>().isActiveAndEnabled)
                    slothLane = sloth.GetComponent<Rotate>().GetCurLane();
                else slothLane = sloth.GetComponent<Rotate_Analog>().GetCurLane();

                spawnLane = slothLane + Random.Range(-1, 2);

                if (spawnLane < 0) spawnLane = numberOfLanes - 1;
                if (spawnLane == numberOfLanes) spawnLane = 0;

                if (sloth.transform.position.y > treeHeight - DistanceFromPlayer)
                    Destroy(this);
                if(Objs.Length > 0)
                    SpawnObject(spawnLane);

                startTime = Time.time;
            }

            //delete / get back to pool if sloth falls 
        }
    }
}