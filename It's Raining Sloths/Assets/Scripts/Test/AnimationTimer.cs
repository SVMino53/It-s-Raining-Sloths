using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTimer : MonoBehaviour
{
    [SerializeField]
    string ParameterName = "ExecutionTime";

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().SetFloat(ParameterName ,Time.time);
    }
}
