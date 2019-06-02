using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentTimer : MonoBehaviour
{
    [SerializeField]
    MonoBehaviour ActivateScript = null;
    [SerializeField]
    float ExecutionTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (ExecutionTime <= Time.time)
        {
            ActivateScript.enabled = true;
        }
    }
}
