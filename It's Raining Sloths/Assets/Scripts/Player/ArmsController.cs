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
    float activePhaseLength = 5.0f;
    [SerializeField]
    string LeftArmName = "Detector_Left";
    [SerializeField]
    string RightArmName = "Detector_Right";

    GameObject rightArm;
    GameObject leftArm;

    bool armActive = false;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        rightArm = GameObject.Find(RightArmName);
        leftArm = GameObject.Find(LeftArmName);
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(CatchRight) && armActive == false)
        {
            rightArm.SetActive(true);
            armActive = true;
        }

        if (Input.GetKeyDown(CatchLeft) && armActive == false)
        {
            leftArm.SetActive(true);
            armActive = true;
        }

        if (Time.time - timer >= activePhaseLength)
        {
            if (leftArm.activeSelf)
                leftArm.SetActive(false);

            if (rightArm.activeSelf)
                rightArm.SetActive(false);

            armActive = false;
            timer = Time.time;
        }
    }
}
