using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAnimationTime : MonoBehaviour
{

    float AnimTime;

    // Start is called before the first frame update
    void Start()
    {
        AnimTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        AnimTime += Time.deltaTime;

        if (AnimTime >= 1.0f)
            AnimTime -= 1.0f;
    }
}
