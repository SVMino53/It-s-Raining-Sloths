using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float startTime;
    [SerializeField]
    float levelLength;
    [SerializeField]
    Text time;

    bool playerReachedTheTop = false;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    { 
        if(Time.time - startTime>=levelLength && !playerReachedTheTop)
        {
            //you lost
        } else {
            time.text = ((int)levelLength - ((int)(Time.time - startTime))).ToString();
        }
    }
}
