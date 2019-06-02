using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTimer : MonoBehaviour
{
    [SerializeField]
    string ParameterName = "Execute";
    [SerializeField]
    float ExecutionTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (ExecutionTime <= Time.timeSinceLevelLoad)
        {
            GetComponent<Animator>().SetBool(ParameterName, true);
        }
    }
}
