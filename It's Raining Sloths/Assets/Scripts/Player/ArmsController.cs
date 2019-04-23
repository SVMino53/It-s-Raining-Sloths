using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsController : MonoBehaviour
{
    [SerializeField]
    KeyCode CatchLeft = KeyCode.O;
    [SerializeField]
    KeyCode CatchRight = KeyCode.P;
    [SerializeField]
    float activePhaseLength;

    GameObject rightArm;
    GameObject leftArm;

    bool armActive = false;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        rightArm = GameObject.Find("Detector_Right");
        leftArm = GameObject.Find("Detector_Left");
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(CatchRight) && armActive == false)
        {
            rightArm.GetComponent<CatchDetection>().SetActive(true);
            armActive = true;
        }

        if (Input.GetKeyDown(CatchLeft) && armActive == false)
        {
            leftArm.GetComponent<CatchDetection>().SetActive(true);
            armActive = true;
        }

        if (Time.time - timer >= activePhaseLength)
        {
            if (leftArm.GetComponent<CatchDetection>().GetActiveStatus())
                leftArm.GetComponent<CatchDetection>().SetActive(false);

            if (rightArm.GetComponent<CatchDetection>().GetActiveStatus())
                rightArm.GetComponent<CatchDetection>().SetActive(false);

            armActive = false;
            timer = Time.time;
        }
    }
}
