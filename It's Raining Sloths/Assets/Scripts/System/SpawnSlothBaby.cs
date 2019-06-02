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

    bool spawn = true;

    GameObject player;
    GameObject obj;
    [SerializeField]
    float treeHeight;
    [SerializeField]
    GameObject spawner;
    [SerializeField]
    float defaultTreeHeight = 70;

    // Start is called before the first frame update 
    void Start()
    {
        if (GameObject.Find(TreesName))
            treeHeight = GameObject.Find(TreesName).GetComponent<InitializeTrees>().GetTreeHeight();
        else treeHeight = defaultTreeHeight;
        player = GameObject.FindGameObjectWithTag(PlayerTag);
        slothLane = player.GetComponent<Rotate>().GetCurLane();
        startTime = Time.time;
    }

    void SpawnObject(int lane)
    {
        Quaternion ObjRotation = Quaternion.Euler(new Vector3(0, 360.0f / numberOfLanes * (lane), 0));
        testRotation = 360.0f / numberOfLanes * (lane);

        int rnd  = Random.Range(0, Objs.Length);
        
        obj = Instantiate<GameObject>(Objs[rnd], new Vector3(2.0f, spawner.transform.position.y, 0.0f), ObjRotation);
        obj.transform.RotateAround(new Vector3(0, transform.position.y, 0), new Vector3(0,1,0), -testRotation+90);
    }

    // Update is called once per frame 
    void Update()
    {
        if (Time.time - startTime >= spawnRate && spawn)
        {
            if (player != null)
            {
                if (player.GetComponent<Rotate>().isActiveAndEnabled)
                    slothLane = player.GetComponent<Rotate>().GetCurLane();
                else slothLane = player.GetComponent<Rotate_Analog>().GetCurLane();

                spawnLane = slothLane + Random.Range(-1, 2);

                if (spawnLane < 0) spawnLane = numberOfLanes - 1;
                if (spawnLane == numberOfLanes) spawnLane = 0;

                if (player.transform.position.y > treeHeight - DistanceFromPlayer)
                    Destroy(this);
                if(Objs.Length > 0)
                    SpawnObject(spawnLane);

                startTime = Time.time;
            }

            //delete / get back to pool if sloth falls 
        }
    }
    public string GetPrefabName()
    {
        return obj.name;
    }
    public void SetSpawningStatus(bool sp)
    {
        spawn = sp;
    }

    public bool GetSpawningStatus()
    {
        return spawn;
    }
}